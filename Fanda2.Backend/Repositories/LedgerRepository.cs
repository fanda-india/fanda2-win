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
            string qry = "SELECT l.id Id, l.code Code, l.ledger_name LedgerName, " +
                "l.ledger_desc LedgerDesc, g.group_name GroupName, " +
                "l.ledger_type LedgerType, l.is_enabled IsEnabled " +
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
                return con.Query<LedgerListModel>(qry).ToList();
            }
        }
    }
}