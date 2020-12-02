namespace Fanda2.Backend.Database
{
    public class LedgerBalance
    {
        public string LedgerId { get; set; }
        public string YearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string BalanceSign { get; set; }
    }
}
