using System;

namespace Fanda2.Backend.ViewModels
{
    public class AccountYearListModel
    {
        public int Id { get; set; }
        public string YearCode { get; set; }
        public DateTime YearBegin { get; set; }
        public DateTime YearEnd { get; set; }
        public bool IsEnabled { get; set; }
        //public int OrgId { get; set; }
    }
}
