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
                {
                    return new LedgerBalance { LedgerId = ledgerId, YearId = yearId };
                }
                else
                {
                    return balance;
                }
            }
        }

        public int? Save(int ledgerId, LedgerBalance balance, IDbConnection con, IDbTransaction tran)
        {
            if (balance == null)
            {
                return null;
            }

            if (ledgerId <= 0 || balance.YearId <= 0)
            {
                throw new ArgumentNullException("LedgerId or YearId of LedgerBalance is null");
            }

            balance.LedgerId = ledgerId;
            // Insert
            if (balance.Id == 0)
            {
                if (balance.IsEmpty())
                {
                    return null;
                }
                int id = Convert.ToInt32(con.Insert(balance));
                balance.Id = id;
                return id;
            }
            // Update
            else
            {
                if (balance.IsEmpty())
                {
                    if (RemoveById(balance.Id, con, tran))
                    {
                        return null;
                    }

                    return balance.Id;
                }
                else
                {
                    con.Update(balance, tran);
                    return balance.Id;
                }
            }
        }

        public bool RemoveById(int ledgerId, int yearId, IDbConnection con, IDbTransaction tran)
        {
            if (ledgerId == 0 || yearId == 0)
            {
                throw new ArgumentNullException("LedgerId or YearId of LedgerBalance is null");
            }

            int rows = con.Execute("DELETE FROM ledger_balances WHERE ledger_id=@ledgerId AND year_id=@yearId", new { ledgerId, yearId }, tran);
            return rows == 1;
        }

        public bool RemoveById(int id, IDbConnection con, IDbTransaction tran)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Id of LedgerBalance is null");
            }

            int rows = con.Execute("DELETE FROM ledger_balances WHERE id=@id", new { id }, tran);
            return rows == 1;
        }

        public bool RemoveAll(int ledgerId, IDbConnection con, IDbTransaction tran)
        {
            if (ledgerId <= 0)
            {
                throw new ArgumentNullException("LedgerId of LedgerBalance is null");
            }

            int rows = con.Execute("DELETE FROM ledger_balances WHERE ledger_id=@ledgerId", new { ledgerId }, tran);
            return rows == 1;
        }
    }
}
