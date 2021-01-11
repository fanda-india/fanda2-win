using Fanda2.Backend.Enums;

using System;

namespace Fanda2.Backend.Database
{
    public class Journal
    {
        public int Id { get; set; }
        public string JournalNumber { get; set; }
        public DateTime JournalDate { get; set; }
        public JournalType JournalType { get; set; }
        public string JournalSign { get; set; }
        public int LedgerId { get; set; }
        public int YearId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Journal Clone()
        {
            return (Journal)MemberwiseClone();
        }
    }
}
