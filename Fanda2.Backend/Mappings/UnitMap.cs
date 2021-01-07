using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

namespace Fanda2.Backend.Mappings
{
    internal class UnitMap : DommelEntityMap<Unit>
    {
        internal UnitMap()
        {
            ToTable("units");

            Map(u => u.Id).ToColumn("id").IsKey();
            Map(u => u.Code).ToColumn("code");
            Map(u => u.UnitName).ToColumn("unit_name");
            Map(u => u.UnitDesc).ToColumn("unit_desc");
            Map(u => u.OrgId).ToColumn("org_id");
            Map(u => u.IsEnabled).ToColumn("is_enabled");
            Map(u => u.CreatedAt).ToColumn("created_at");
            Map(u => u.UpdatedAt).ToColumn("updated_at");
        }
    }

    internal class UnitListMap : DommelEntityMap<UnitListModel>
    {
        internal UnitListMap()
        {
            ToTable("units");

            Map(u => u.Id).ToColumn("id").IsKey();
            Map(u => u.Code).ToColumn("code");
            Map(u => u.UnitName).ToColumn("unit_name");
            Map(u => u.UnitDesc).ToColumn("unit_desc");
            Map(u => u.IsEnabled).ToColumn("is_enabled");
            //Map(u => u.OrgId).ToColumn("org_id");
        }
    }
}
