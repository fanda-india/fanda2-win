namespace Fanda2.Backend.Database
{
    public class LedgerBalance
    {
        public int Id { get; set; }
        public int LedgerId { get; set; }
        public int YearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string BalanceSign { get; set; }
    }
}
