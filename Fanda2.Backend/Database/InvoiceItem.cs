namespace Fanda2.Backend.Database
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int InventoryId { get; set; }
        public string ItemDesc { get; set; }

        public int UnitId { get; set; }
        public decimal Qty { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPct { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal TaxPct { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal LineTotal { get; set; }
    }
}
