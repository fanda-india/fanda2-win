using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class OrganizationRepository : IRepository<Organization, OrganizationListModel>
    {
        private readonly SQLiteDB _db;
        private readonly AddressRepository _addressRepository;
        private readonly ContactRepository _contactRepository;

        public OrganizationRepository()
        {
            _db = new SQLiteDB();
            _addressRepository = new AddressRepository();
            _contactRepository = new ContactRepository();
        }

        public List<OrganizationListModel> GetAll(string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.GetAll<OrganizationListModel>()
                        .ToList();
                }
                else
                {
                    return con.Select<OrganizationListModel>(o =>
                         o.Code.Contains(searchTerm) ||
                         o.OrgName.Contains(searchTerm) ||
                         o.OrgDesc.Contains(searchTerm)
                    ).ToList();
                }
            }
        }

        public Organization GetById(int id)
        {
            using (var con = _db.GetConnection())
            {
                return con.Get<Organization, Address, Contact, Organization>(id);
            }
        }

        public int Create(Organization entity)
        {
            entity.CreatedAt = DateTime.Now;
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    int? addressId = _addressRepository.Save(entity.Address, con, tran);
                    int? contactId = _contactRepository.Save(entity.Contact, con, tran);
                    entity.AddressId = addressId;
                    entity.ContactId = contactId;
                    con.Insert(entity, tran);

                    tran.Commit();
                    return entity.Id;
                }
            }
        }

        public bool Update(int id, Organization entity)
        {
            if (id <= 0 || id != entity.Id)
            {
                return false;
            }

            entity.UpdatedAt = DateTime.Now;
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    int? addressId = _addressRepository.Save(entity.Address, con, tran);
                    int? contactId = _contactRepository.Save(entity.Contact, con, tran);
                    entity.AddressId = addressId;
                    entity.ContactId = contactId;
                    bool success = con.Update(entity, tran);
                    tran.Commit();
                    return success;
                }
            }
        }

        public bool Remove(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                Organization org = con.Get<Organization>(id);
                if (org == null)
                    return false;

                using (var tran = con.BeginTransaction())
                {
                    _addressRepository.Remove(org.AddressId, con, tran);
                    _contactRepository.Remove(org.ContactId, con, tran);
                    bool success = con.Delete(org, tran);
                    tran.Commit();
                    return success;
                }
            }
        }
    }
}