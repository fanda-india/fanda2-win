using Dommel;

using Fanda2.Backend.Database;

using System.Linq;

namespace Fanda2.Backend.Repositories
{
    internal class LedgerGroupRepository
    {
        private readonly SQLiteDB _db;

        internal LedgerGroupRepository()
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
    }
}
