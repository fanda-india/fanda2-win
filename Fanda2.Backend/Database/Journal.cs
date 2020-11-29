using System;

namespace Fanda2.Backend.Database
{
    public class Journal
    {
        public Guid Id { get; set; }
        public string JournalNumber { get; set; }
        public DateTime JournalDate { get; set; }
        public JournalType JournalType { get; set; }
        public string JournalSign { get; set; }
        public Guid LedgerId { get; set; }
        public Guid YearId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}