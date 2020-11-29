using System;

namespace Fanda2.Backend.Database
{
    public class LedgerBalance
    {
        public Guid LedgerId { get; set; }
        public Guid YearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string BalanceSign { get; set; }
    }
}