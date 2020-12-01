using System;

namespace Fanda2.Backend.Database
{
    public class JournalItem
    {
        public string Id { get; set; }
        public string JournalId { get; set; }
        public string LedgerId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string JournalDesc { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
    }
}
