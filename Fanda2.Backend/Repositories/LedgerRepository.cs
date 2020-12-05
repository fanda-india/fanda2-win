using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
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

        public Ledger UpdateBalance(Ledger ledger, int ledgerId, int yearId)
        {
            var balance = _balanceRepository.Get(ledgerId, yearId);
            ledger.Balance = balance;
            return ledger;
        }

        public int Create(int orgId, Ledger ledger)
        {
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    int ledgerId = Create(orgId, ledger, con, tran);
                    tran.Commit();
                    return ledgerId;
                }
            }
        }

        public int Create(int orgId, Ledger ledger, IDbConnection con, IDbTransaction tran)
        {
            ledger.OrgId = orgId;
            ledger.CreatedAt = DateTime.Now;

            int ledgerId = Convert.ToInt32(con.Insert(ledger, tran));
            ledger.Id = ledgerId;
            _bankRepository.Save(ledgerId, ledger.Bank, con, tran);
            _partyRepository.Save(ledgerId, ledger.Party, con, tran);
            _balanceRepository.Save(ledger.Balance, con, tran);
            return ledgerId;
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
                    _balanceRepository.Save(ledger.Balance, con, tran);
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
                    // TODO: Remove LedgerBalance for active accounting year
                    //_balanceRepository.RemoveById(ledgerId, con, tran);
                    int rows = con.Execute("DELETE FROM ledgers WHERE id=@ledgerId", new { ledgerId }, tran);
                    tran.Commit();
                    return rows == 1;
                }
            }
        }
    }
}

//SELECT l.id, l.code, l.ledger_name, l.ledger_desc, l.ledger_type, l.is_enabled,
//g.group_name
//FROM ledgers l
//INNER JOIN ledger_groups g ON l.group_id = g.id

//SELECT l.*,
//b.ledger_id BankId, b.*, ba.id BankAddrId, ba.*, bc.id BankContactId, bc.*,
//p.ledger_id PartyId, p.*, pa.id PartyAddrId, pa.*, pc.id PartyContactId, pc.*
//FROM ledgers l
//LEFT JOIN banks b ON l.id = b.ledger_id
//    LEFT JOIN addresses ba ON b.address_id = ba.id
//    LEFT JOIN contacts bc ON b.contact_id = bc.id
//LEFT JOIN parties p ON l.id = p.ledger_id
//    LEFT JOIN addresses pa ON p.address_id = pa.id
//    LEFT JOIN contacts pc ON p.contact_id = pc.id
//WHERE l.id= @id

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
