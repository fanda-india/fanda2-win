using Fanda2.Backend.Database;

namespace Fanda2.Backend.Repositories
{
    internal class BankRepository : SubLedgerRepositoryBase<Bank>
    {
    }

    //public class BankRepository : ISubRepository<Bank>
    //{
    //    private readonly AddressRepository _addressRepository;
    //    private readonly ContactRepository _contactRepository;

    //    public BankRepository()
    //    {
    //        _addressRepository = new AddressRepository();
    //        _contactRepository = new ContactRepository();
    //    }

    //    public bool Save(int ledgerId, Bank entity, IDbConnection con, IDbTransaction tran)
    //    {
    //        if (ledgerId <= 0)
    //            return false;

    //        entity.LedgerId = ledgerId;
    //        bool found = con.Any<Bank>(b => b.LedgerId == ledgerId);
    //        // Insert
    //        if (!found)
    //        {
    //            // No data, skip
    //            if (entity.IsEmpty())
    //                return true;

    //            // Insert
    //            int? addressId = _addressRepository.Save(entity.Address, con, tran);
    //            int? contactId = _contactRepository.Save(entity.Contact, con, tran);
    //            entity.AddressId = addressId;
    //            entity.ContactId = contactId;
    //            int bankId = Convert.ToInt32(con.Insert(entity, tran));
    //            return bankId > 0;
    //        }
    //        // Update/Delete
    //        else
    //        {
    //            // Delete
    //            if (entity.IsEmpty())
    //                return Remove(ledgerId, con, tran);

    //            // Update
    //            int? addressId = _addressRepository.Save(entity.Address, con, tran);
    //            int? contactId = _contactRepository.Save(entity.Contact, con, tran);
    //            entity.AddressId = addressId;
    //            entity.ContactId = contactId;
    //            return con.Update(entity, tran);
    //        }
    //    }

    //    public bool Remove(int ledgerId, IDbConnection con, IDbTransaction tran)
    //    {
    //        if (ledgerId <= 0)
    //            return false;

    //        Bank bank = con.Select<Bank>(b => b.LedgerId == ledgerId)
    //            .FirstOrDefault();
    //        if (bank == null)
    //            return true;

    //        _addressRepository.Remove(bank.AddressId, con, tran);
    //        _contactRepository.Remove(bank.ContactId, con, tran);
    //        return con.Delete(bank, tran);
    //    }
    //}
}
