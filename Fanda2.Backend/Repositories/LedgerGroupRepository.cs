using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public class LedgerGroupRepository
    {
        private readonly SQLiteDB _db;

        public LedgerGroupRepository()
        {
            _db = new SQLiteDB();
        }

        public LedgerGroup GetByCode(string code)
        {
            using (var con = _db.GetConnection())
            {
                return con.Select<LedgerGroup>(lg => lg.Code == code)
                    .FirstOrDefault();
            }
        }

        public List<LedgerGroupListModel> GetAll()
        {
            using (var con = _db.GetConnection())
            {
                // Fetch from database
                var list = con.Query<LedgerGroupListModel>($"select id, code, group_name from ledger_groups")
                    .ToList();
                return list;
            }
        }
    }
}