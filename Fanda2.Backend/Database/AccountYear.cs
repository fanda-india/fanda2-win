using System;

namespace Fanda2.Backend.Database
{
    public class AccountYear
    {
        public int Id { get; set; }
        public string YearCode { get; set; }
        public DateTime YearBegin { get; set; }
        public DateTime YearEnd { get; set; }
        public int OrgId { get; set; }
    }
}
