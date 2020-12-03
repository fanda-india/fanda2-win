using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class LedgerRepository : IRepository<Ledger, LedgerListModel>
    {
        internal readonly SQLiteDB _db;

        public LedgerRepository()
        {
            _db = new SQLiteDB();
        }

        public virtual List<LedgerListModel> GetAll(string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.GetAll<LedgerListModel>()
                        .ToList();
                }
                else
                {
                    return con.Select<LedgerListModel>(o =>
                         o.Code.Contains(searchTerm) ||
                         o.LedgerName.Contains(searchTerm) ||
                         o.LedgerDesc.Contains(searchTerm) ||
                         o.GroupName.Contains(searchTerm)
                    ).ToList();
                }
            }
        }

        public virtual Ledger GetById(int id)
        {
            using (var con = _db.GetConnection())
            {
                return con.Get<Ledger>(id);
            }
        }

        public virtual int Create(Ledger entity)
        {
            entity.CreatedAt = DateTime.Now;
            using (var con = _db.GetConnection())
            {
                con.Insert(entity);
                return entity.Id;
            }
        }

        public virtual bool Update(int id, Ledger entity)
        {
            if (id <= 0 || id != entity.Id)
            {
                return false;
            }

            entity.UpdatedAt = DateTime.Now;
            using (var con = _db.GetConnection())
            {
                return con.Update(entity);
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
                long rows = con.Execute("DELETE FROM ledgers WHERE id=@id", new { id });
                return rows == 1;
            }
        }
    }
}

//using (var con = _db.GetConnection())
//{
//    var result = con.Query<Ledger, Bank, Address, Contact, Party, Address, Contact, Ledger>(qry,
//        (ledger, bank, ba, bc, party, pa, pc) =>
//        {
//            ledger.Bank = bank;
//            bank.Address = ba;
//            bank.Contact = bc;
//            ledger.Party = party;
//            party.Address = pa;
//            party.Contact = pc;
//            return ledger;
//        }, new { id },
//        splitOn: "id,BankId,BankAddrId,BankContactId,PartyId,PartyAddrId,PartyContactId")
//        .FirstOrDefault();
//    return result;
//}