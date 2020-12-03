using System;

namespace Fanda2.Backend.Database
{
    public class Transaction
    {
        public int Id { get; set; }
        public int DebitLedgerId { get; set; }
        public int CreditLedgerId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string TranDesc { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public int? JournalId { get; set; }        // nullable
        public int? InvoiceId { get; set; }        // nullable
    }
}