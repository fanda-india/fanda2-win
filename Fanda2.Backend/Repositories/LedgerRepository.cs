using Dapper;
using Dapper.Contrib.Extensions;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public class LedgerRepository
    {
        private readonly DbConnection _connection;

        public LedgerRepository()
        {
            _connection = new DbConnection();
        }

        public List<LedgerListModel> GetAll(string searchTerm = null)
        {
            string qry =
                "SELECT l.id, l.code, l.ledger_name, l.ledger_desc, l.ledger_type, l.is_enabled, " +
                "g.group_name " +
                "FROM ledgers l " +
                "INNER JOIN ledger_groups g ON l.group_id = g.id";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                qry += $" WHERE l.code LIKE '%{searchTerm}%' OR " +
                    $"l.ledger_name LIKE '%{searchTerm}%' OR " +
                    $"l.ledger_desc LIKE '%{searchTerm}%' OR " +
                    $"g.group_name LIKE '%{searchTerm}%'";
            }

            using (var con = _connection.GetConnection())
            {
                var result = con.Query<LedgerListModel>(qry).ToList();
                return result;
            }
        }

        public Ledger GetById(string id)
        {
            var qry = "SELECT l.*, " +
                "b.ledger_id BankId, b.*, ba.id BankAddrId, ba.*, bc.id BankContactId, bc.*,  " +
                "p.ledger_id PartyId, p.*, pa.id PartyAddrId, pa.*, pc.id PartyContactId, pc.* " +
                "FROM ledgers l " +
                "LEFT JOIN banks b ON l.id = b.ledger_id " +
                "    LEFT JOIN addresses ba ON b.address_id = ba.id " +
                "    LEFT JOIN contacts bc ON b.contact_id = bc.id " +
                "LEFT JOIN parties p ON l.id = p.ledger_id " +
                "    LEFT JOIN addresses pa ON p.address_id = pa.id " +
                "    LEFT JOIN contacts pc ON p.contact_id = pc.id " +
                "WHERE l.id=@id";

            using (var con = _connection.GetConnection())
            {
                var result = con.Query<Ledger, Bank, Address, Contact, Party, Address, Contact, Ledger>(qry,
                    (ledger, bank, ba, bc, party, pa, pc) =>
                    {
                        ledger.Bank = bank;
                        bank.Address = ba;
                        bank.Contact = bc;
                        ledger.Party = party;
                        party.Address = pa;
                        party.Contact = pc;
                        return ledger;
                    }, new { id },
                    splitOn: "id,BankId,BankAddrId,BankContactId,PartyId,PartyAddrId,PartyContactId")
                    .FirstOrDefault();
                return result;
            }
        }

        public bool Create(Ledger ledger)
        {
        }
    }
}