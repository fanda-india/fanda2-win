using System;

namespace Fanda2.Backend.Database
{
    public class LedgerGroup
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public LedgerGroupType GroupType { get; set; }
        public string ParentId { get; set; }
        public bool IsSystem { get; set; }
        public string OrgId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
