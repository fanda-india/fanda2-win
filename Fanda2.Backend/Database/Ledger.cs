using Fanda2.Backend.Enums;
using Fanda2.Backend.ViewModels;

using System;

namespace Fanda2.Backend.Database
{
    public class Ledger
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string LedgerName { get; set; }
        public string LedgerDesc { get; set; }
        public int LedgerGroupId { get; set; }
        public LedgerType LedgerType { get; set; }
        public bool IsSystem { get; set; }
        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; internal set; }
        public DateTime? UpdatedAt { get; internal set; }

        #region Virtual Members

        public virtual LedgerBalance Balance { get; set; }
        public virtual Bank Bank { get; set; }

        public virtual Party Party { get; set; }

        #endregion Virtual Members

        public Ledger Clone()
        {
            return (Ledger)MemberwiseClone();
        }

        //public Ledger FromLedgerListModel(LedgerListModel model)
        //{
        //    return new Ledger
        //    {
        //        Id = model.Id,
        //        Code = model.Code,
        //        LedgerName = model.LedgerName,
        //        LedgerDesc = model.LedgerDesc,
        //        LedgerGroupId = model.LedgerGroupId,
        //        LedgerType = model.LedgerType,
        //        IsEnabled = model.IsEnabled
        //    };
        //}
    }
}
