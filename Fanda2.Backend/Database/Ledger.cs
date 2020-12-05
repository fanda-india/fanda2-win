using Fanda2.Backend.Enums;

using System;

namespace Fanda2.Backend.Database
{
    public class Ledger
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string LedgerName { get; set; }
        public string LedgerDesc { get; set; }
        public int LedgerGroupId { get; set; }
        public LedgerType LedgerType { get; set; }
        public bool IsSystem { get; set; }
        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Ledger Balance

        //public int YearId { get; set; }
        //public decimal OpeningBalance { get; set; }
        //public string BalanceSign { get; set; }
        public virtual LedgerBalance Balance { get; set; }

        // Virtual Members

        public virtual Bank Bank { get; set; }
        public virtual Party Party { get; set; }
    }
}
