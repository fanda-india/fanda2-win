using Dommel;

using System;
using System.Data;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    internal interface ISubRepository<Entity>
    {
        bool Save(int superId, Entity entity, IDbConnection con, IDbTransaction tran);

        bool Remove(int superId, IDbConnection con, IDbTransaction tran);
    }

    internal abstract class SubLedgerRepositoryBase<TEntity> : ISubRepository<TEntity> where TEntity : class, ISubLedger
    {
        private readonly AddressRepository _addressRepository;
        private readonly ContactRepository _contactRepository;

        public SubLedgerRepositoryBase()
        {
            _addressRepository = new AddressRepository();
            _contactRepository = new ContactRepository();

            DommelMapper.LogReceived = (qry) =>
            {
                System.Diagnostics.Debug.WriteLine("LOG: " + qry);
            };
        }

        public virtual bool Save(int ledgerId, TEntity entity, IDbConnection con, IDbTransaction tran)
        {
            if (ledgerId <= 0)
            {
                return false;
            }

            if (entity == null)
            {
                return true;
            }

            entity.LedgerId = ledgerId;
            bool found = con.Any<TEntity>(b => b.LedgerId == ledgerId);
            // Insert
            if (!found)
            {
                // No data, skip
                if (entity.IsEmpty())
                {
                    return true;
                }

                // Insert
                int? addressId = _addressRepository.Save(entity.Address, con, tran);
                int? contactId = _contactRepository.Save(entity.Contact, con, tran);
                entity.AddressId = addressId;
                entity.ContactId = contactId;
                int entityId = Convert.ToInt32(con.Insert(entity, tran));
                return entityId > 0;
            }
            // Update/Delete
            else
            {
                // Delete
                if (entity.IsEmpty())
                {
                    return Remove(ledgerId, con, tran);
                }

                // Update
                int? addressId = _addressRepository.Save(entity.Address, con, tran);
                int? contactId = _contactRepository.Save(entity.Contact, con, tran);
                entity.AddressId = addressId;
                entity.ContactId = contactId;
                return con.Update(entity, tran);
            }
        }

        public virtual bool Remove(int ledgerId, IDbConnection con, IDbTransaction tran)
        {
            if (ledgerId <= 0)
            {
                return false;
            }

            TEntity entity = con.Select<TEntity>(b => b.LedgerId == ledgerId, tran)
                .FirstOrDefault();
            if (entity == null)
            {
                return true;
            }

            _addressRepository.Remove(entity.AddressId, con, tran);
            _contactRepository.Remove(entity.ContactId, con, tran);
            return con.Delete(entity, tran);
        }
    }
}
