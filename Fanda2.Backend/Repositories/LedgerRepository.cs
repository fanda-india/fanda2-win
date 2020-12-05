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
        private readonly SQLiteDB _db;
        private readonly BankRepository _bankRepository;
        private readonly PartyRepository _partyRepository;
        private readonly LedgerBalanceRepository _balanceRepository;

        public LedgerRepository()
        {
            _db = new SQLiteDB();
            _bankRepository = new BankRepository();
            _partyRepository = new PartyRepository();
            _balanceRepository = new LedgerBalanceRepository();
        }

        public List<LedgerListModel> GetAll(int orgId, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select<LedgerListModel>(l => l.OrgId == orgId)
                        .ToList();
                }
                else
                {
                    return con.Select<LedgerListModel>(l =>
                        l.OrgId == orgId &&
                        (l.Code.Contains(searchTerm) ||
                        l.LedgerName.Contains(searchTerm) ||
                        l.LedgerDesc.Contains(searchTerm) ||
                        l.GroupName.Contains(searchTerm))
                    ).ToList();
                }
            }
        }

        public Ledger GetById(int id)
        {
            using (var con = _db.GetConnection())
            {
                return con.Get<Ledger>(id);
            }
        }

        public LedgerBalance GetBalance(int ledgerId, int yearId)
        {
            return _balanceRepository.Get(ledgerId, yearId);
        }

        public int Create(int orgId, Ledger ledger)
        {
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    ledger.OrgId = orgId;
                    ledger.CreatedAt = DateTime.Now;

                    int ledgerId = Convert.ToInt32(con.Insert(ledger, tran));
                    ledger.Id = ledgerId;
                    _bankRepository.Save(ledgerId, ledger.Bank, con, tran);
                    _partyRepository.Save(ledgerId, ledger.Party, con, tran);
                    _balanceRepository.Save(ledger.LedgerBalance, con, tran);

                    tran.Commit();
                    return ledgerId;
                }
            }
        }

        public bool Update(int ledgerId, Ledger ledger)
        {
            if (ledgerId <= 0 || ledgerId != ledger.Id)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    ledger.UpdatedAt = DateTime.Now;
                    bool success = con.Update(ledger);
                    _bankRepository.Save(ledger.Id, ledger.Bank, con, tran);
                    _partyRepository.Save(ledger.Id, ledger.Party, con, tran);
                    _balanceRepository.Save(ledger.LedgerBalance, con, tran);
                    tran.Commit();
                    return success;
                }
            }
        }

        public bool Remove(int ledgerId)
        {
            if (ledgerId <= 0)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                //Ledger ledger = con.Get<Ledger>(ledgerId);
                //if (ledger == null)
                //    return false;

                using (var tran = con.BeginTransaction())
                {
                    _bankRepository.Remove(ledgerId, con, tran);
                    _partyRepository.Remove(ledgerId, con, tran);
                    _balanceRepository.RemoveBalances(ledgerId, con, tran);
                    int rows = con.Execute("DELETE FROM ledgers WHERE id=@ledgerId", new { ledgerId }, tran);
                    tran.Commit();
                    return rows == 1;
                }
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