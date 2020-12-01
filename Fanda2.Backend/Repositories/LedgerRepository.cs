using Dapper.Contrib.Extensions;

using Fanda2.Backend.Database;

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

        public List<Ledger> GetAll(string searchTerm = null)
        {
            using (var con = _connection.GetConnection())
            {
                return con.GetAll<Ledger>().ToList();
            }
        }
    }
}
