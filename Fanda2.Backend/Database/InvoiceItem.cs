using System;

namespace Fanda2.Backend.Database
{
    public class InvoiceItem
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public string StockId { get; set; }
        public string ItemDesc { get; set; }

        public string UnitId { get; set; }
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
