namespace Fanda2.Backend.Database
{
    public class LedgerBalance
    {
        public int LedgerId { get; set; }
        public int YearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string BalanceSign { get; set; }
    }
}