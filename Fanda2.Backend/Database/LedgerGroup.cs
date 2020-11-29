using System;

namespace Fanda2.Backend.Database
{
    public class LedgerGroup
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LedgerGroupType GroupType { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsSystem { get; set; }
        public Guid OrgId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}