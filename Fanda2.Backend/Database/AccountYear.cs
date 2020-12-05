using System;

namespace Fanda2.Backend.Database
{
    public class AccountYear : IMaster
    {
        private string _yearCode;

        public int Id { get; set; }

        public string YearCode
        {
            get => string.IsNullOrWhiteSpace(_yearCode) ? GetYearCode() : _yearCode;
            internal set { _yearCode = value; }
        }

        public DateTime YearBegin { get; set; }
        public DateTime YearEnd { get; set; }
        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsEmpty()
        {
            return YearBegin == default &&
                YearEnd == default;
        }

        private string GetYearCode()
        {
            if (!IsEmpty())
                return $"{YearBegin.ToString("yyyy")}-{YearEnd.ToString("yyyy")}";
            else
                return string.Empty;
        }
    }
}
