using System;

namespace Fanda2.Backend.Database
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid DebitLedgerId { get; set; }
        public Guid CreditLedgerId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public Guid? JournalId { get; set; }
        public Guid? InvoiceId { get; set; }
    }
}