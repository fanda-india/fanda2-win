using System;

namespace Fanda2.Backend.Database
{
    public class Journal
    {
        public string Id { get; set; }
        public string JournalNumber { get; set; }
        public DateTime JournalDate { get; set; }
        public JournalType JournalType { get; set; }
        public string JournalSign { get; set; }
        public string LedgerId { get; set; }
        public string YearId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
