using Dapper;

using Dommel;

using Fanda2.Backend.Database;

using System;
using System.Data;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    internal class LedgerBalanceRepository
    {
        private readonly SQLiteDB _db;

        internal LedgerBalanceRepository()
        {
            _db = new SQLiteDB();
        }

        public LedgerBalance Get(int ledgerId, int yearId)
        {
            using (var con = _db.GetConnection())
            {
                var balance = con.Select<LedgerBalance>(lb => lb.LedgerId == ledgerId && lb.YearId == yearId)
                    .FirstOrDefault();

                if (balance == null)
                    return new LedgerBalance { LedgerId = ledgerId, YearId = yearId };
                else
                    return balance;
            }
        }

        public int? Save(LedgerBalance entity, IDbConnection con, IDbTransaction tran)
        {
            if (entity == null)
                throw new ArgumentNullException("Ledger balance is null");

            if (entity.LedgerId <= 0 || entity.YearId <= 0)
                throw new ArgumentNullException("LedgerId or YearId is null");

            // Insert
            if (entity.Id == 0)
            {
                if (entity.IsEmpty())
                    return null;

                //entity.LedgerId = ledgerId;
                //entity.YearId = yearId;
                int id = Convert.ToInt32(con.Insert(entity));
                return id;
            }
            // Update
            else
            {
                if (entity.IsEmpty())
                {
                    if (Remove(entity.Id, con, tran))
                    {
                        return null;
                    }

                    return entity.Id;
                }
                else
                {
                    con.Update(entity, tran);
                    return entity.Id;
                }
            }
        }

        public bool Remove(int id, IDbConnection con, IDbTransaction tran)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id of LedgerBalance is null");

            //LedgerBalance entity = con.Get<LedgerBalance>(id);
            //if (entity == null)
            //{
            //    return false;
            //}

            int rows = con.Execute("DELETE FROM ledger_balances WHERE id=@id", new { id }, tran);
            return rows == 1;
        }

        public bool RemoveBalances(int ledgerId, IDbConnection con, IDbTransaction tran)
        {
            if (ledgerId <= 0)
                throw new ArgumentNullException("LedgerId of LedgerBalance is null");

            //LedgerBalance entity = con.Get<LedgerBalance>(id);
            //if (entity == null)
            //{
            //    return false;
            //}

            int rows = con.Execute("DELETE FROM ledger_balances WHERE ledger_id=@ledgerId", new { ledgerId }, tran);
            return rows == 1;
        }
    }
}