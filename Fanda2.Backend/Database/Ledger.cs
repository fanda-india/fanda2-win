using Dapper.Contrib.Extensions;

using System;

namespace Fanda2.Backend.Database
{
    [Table("ledgers")]
    public class Ledger
    {
        [ExplicitKey]
        public string Id { get; set; }

        public string Code { get; set; }
        public string LedgerName { get; set; }
        public string LedgerDesc { get; set; }
        public string LedgerGroupId { get; set; }
        public LedgerType LedgerType { get; set; }
        public bool IsSystem { get; set; }
        public string OrgId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
