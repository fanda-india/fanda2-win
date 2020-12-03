using Dommel;

using Fanda2.Backend.Database;

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public class BankRepository //: IRepository<Bank>
    {
        private readonly AddressRepository _addressRepository;
        private readonly ContactRepository _contactRepository;

        public BankRepository()
        {
            _addressRepository = new AddressRepository();
            _contactRepository = new ContactRepository();
        }

        public bool Save(int ledgerId, Bank entity, IDbConnection con, IDbTransaction tran)
        {
            Bank bank = con.Get<Bank>(ledgerId);
            // Insert
            if (bank == null)
            {
            }
            // Update
            else
            {
            }
        }

        public bool Remove(int ledgerId, IDbConnection con, IDbTransaction tran)
        {
            throw new NotImplementedException();
        }
    }
}