using System;

namespace Fanda2.Backend.Database
{
    public class AccountYear : IMaster
    {
        private string _yearCode;
        private DateTime _yearBegin;
        private DateTime _yearEnd;

        public int Id { get; set; }

        public string YearCode
        {
            get => string.IsNullOrWhiteSpace(_yearCode) ? GetYearCode() : _yearCode;
            internal set { _yearCode = value; }
        }

        public DateTime YearBegin
        {
            get => _yearBegin == DateTime.MinValue ? new DateTime(GetBeginYear(), 4, 1) : _yearBegin;
            set { _yearBegin = value; }
        }

        public DateTime YearEnd
        {
            get => _yearEnd == DateTime.MinValue ? new DateTime(GetEndYear(), 3, 31) : _yearEnd;
            set { _yearEnd = value; }
        }

        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public AccountYear Clone()
        {
            return (AccountYear)MemberwiseClone();
        }

        public bool IsEmpty()
        {
            return YearBegin == default &&
                YearEnd == default;
        }

        #region Private methods

        private string GetYearCode()
        {
            if (!IsEmpty())
            {
                return $"{YearBegin:yyyy}-{YearEnd:yyyy}";
            }
            else
            {
                return string.Empty;
            }
        }

        private int GetBeginYear()
        {
            return DateTime.Today.Month >= 4 && DateTime.Today.Month <= 12 ? DateTime.Today.Year : DateTime.Today.Year - 1;
        }

        private int GetEndYear()
        {
            return DateTime.Today.Month >= 4 && DateTime.Today.Month <= 12 ? DateTime.Today.Year + 1 : DateTime.Today.Year;
        }

        #endregion Private methods
    }
}
