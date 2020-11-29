using System;

namespace Fanda2.Backend.Database
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceType InvoiceType { get; set; }

        //public StockInvoiceType StockInvoiceType { get; set; }
        public GstTreatment GstTreatment { get; set; }

        public InvoiceTaxPreference TaxPreference { get; set; }
        public string Notes { get; set; }
        public Guid PartyId { get; set; }
        public string RefNum { get; set; }
        public DateTime? RefDate { get; set; }
        public Guid? BuyerId { get; set; }

        // Trailer
        public decimal Subtotal { get; set; }

        public decimal DiscountPct { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal TotalTaxAmt { get; set; }
        public decimal MiscAddDesc { get; set; }
        public decimal MiscAddAmt { get; set; }
        public decimal NetAmount { get; set; }
        public Guid YearId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}