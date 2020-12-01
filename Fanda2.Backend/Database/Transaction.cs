using System;

namespace Fanda2.Backend.Database
{
    public class Transaction
    {
        public string Id { get; set; }
        public string DebitLedgerId { get; set; }
        public string CreditLedgerId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string TranDesc { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public string JournalId { get; set; }        // nullable
        public string InvoiceId { get; set; }        // nullable
    }
}
