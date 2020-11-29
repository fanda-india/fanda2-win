using System;

namespace Fanda2.Backend.Database
{
    public class InvoiceItem
    {
        public Guid InvoiceItemId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid StockId { get; set; }
        public string Description { get; set; }

        public Guid UnitId { get; set; }
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