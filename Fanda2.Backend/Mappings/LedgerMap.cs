using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

namespace Fanda2.Backend.Mappings
{
    internal class LedgerMap : DommelEntityMap<Ledger>
    {
        internal LedgerMap()
        {
            ToTable("ledgers");

            Map(l => l.Id).ToColumn("id").IsKey();
            Map(l => l.Code).ToColumn("code");
            Map(l => l.LedgerName).ToColumn("ledger_name");
            Map(l => l.LedgerDesc).ToColumn("ledger_desc");
            Map(l => l.LedgerGroupId).ToColumn("group_id");
            Map(l => l.LedgerType).ToColumn("ledger_type");
            Map(l => l.IsSystem).ToColumn("is_system");
            Map(l => l.OrgId).ToColumn("org_id");
            Map(l => l.IsEnabled).ToColumn("is_enabled");
            Map(l => l.CreatedAt).ToColumn("created_at");
            Map(l => l.UpdatedAt).ToColumn("updated_at");
            //Map(l => l.GroupName).ToColumn("group_name").Ignore();
        }
    }

    internal class LedgerListMap : DommelEntityMap<LedgerListModel>
    {
        internal LedgerListMap()
        {
            ToTable("ledgers");

            Map(l => l.Id).ToColumn("id").IsKey();
            Map(l => l.Code).ToColumn("code");
            Map(l => l.LedgerName).ToColumn("ledger_name");
            Map(l => l.LedgerDesc).ToColumn("ledger_desc");
            Map(l => l.GroupName).ToColumn("group_name");
            Map(l => l.LedgerType).ToColumn("ledger_type");
            Map(l => l.IsEnabled).ToColumn("is_enabled");
            //Map(l => l.OrgId).ToColumn("org_id");
        }
    }
}