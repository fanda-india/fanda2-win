using Fanda2.Backend.Enums;

using System;

namespace Fanda2.Backend.Database
{
    public class LedgerGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public LedgerGroupType GroupType { get; set; }
        public int? ParentId { get; set; }      // nullable
        public bool IsSystem { get; set; }
        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public LedgerGroup Clone()
        {
            return (LedgerGroup)MemberwiseClone();
        }
    }
}
