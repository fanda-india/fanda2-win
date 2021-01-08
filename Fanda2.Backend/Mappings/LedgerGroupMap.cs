using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

namespace Fanda2.Backend.Mappings
{
    internal class LedgerGroupMap : DommelEntityMap<LedgerGroup>
    {
        internal LedgerGroupMap()
        {
            ToTable("ledger_groups");

            Map(lg => lg.Id).ToColumn("id").IsKey();
            Map(lg => lg.Code).ToColumn("code");
            Map(lg => lg.GroupName).ToColumn("group_name");
            Map(lg => lg.GroupDesc).ToColumn("group_desc");
            Map(lg => lg.GroupType).ToColumn("group_type");
            Map(lg => lg.ParentId).ToColumn("parent_id");
        }
    }

    internal class LedgerGroupListMap : DommelEntityMap<LedgerGroupListModel>
    {
        internal LedgerGroupListMap()
        {
            ToTable("ledger_groups");

            Map(lg => lg.Id).ToColumn("id").IsKey();
            Map(lg => lg.Code).ToColumn("code");
            Map(lg => lg.GroupName).ToColumn("group_name");
        }
    }
}