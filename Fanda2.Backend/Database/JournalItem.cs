using System;

namespace Fanda2.Backend.Database
{
    public class JournalItem
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public int LedgerId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string JournalDesc { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
    }
}