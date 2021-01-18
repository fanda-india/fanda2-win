using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;

namespace Fanda2.Backend.ViewModels
{
    public class LedgerListModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string LedgerName { get; set; }
        public string LedgerDesc { get; set; }
        public int LedgerGroupId { get; set; }
        public string GroupName { get; set; }
        public LedgerType LedgerType { get; set; }
        public bool IsSystem { get; set; }
        public bool IsEnabled { get; set; } = true;

        #region Balance

        public int BalanceId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string BalanceSign { get; set; }

        #endregion Balance

        // public LedgerBalance Balance { get; set; }
        public Ledger ToLedger(int yearId)
        {
            return new Ledger
            {
                Id = Id,
                Code = Code,
                LedgerName = LedgerName,
                LedgerDesc = LedgerDesc,
                LedgerGroupId = LedgerGroupId,
                LedgerType = LedgerType,
                IsEnabled = IsEnabled,
                Balance = new LedgerBalance
                {
                    LedgerId = Id,
                    OpeningBalance = OpeningBalance,
                    BalanceSign = BalanceSign,
                    Id = BalanceId,
                    YearId = yearId
                }
            };
        }
    }
}
