using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

namespace Fanda2.Backend.Mappings
{
    internal class AccountYearMap : DommelEntityMap<AccountYear>
    {
        internal AccountYearMap()
        {
            ToTable("account_years");

            Map(u => u.Id).ToColumn("id").IsKey();
            Map(u => u.YearCode).ToColumn("year_code");
            Map(u => u.YearBegin).ToColumn("year_begin");
            Map(u => u.YearEnd).ToColumn("year_end");
            Map(u => u.OrgId).ToColumn("org_id");
            Map(u => u.IsEnabled).ToColumn("is_enabled");
            Map(u => u.CreatedAt).ToColumn("created_at");
            Map(u => u.UpdatedAt).ToColumn("updated_at");
        }
    }

    internal class AccountYearListMap : DommelEntityMap<AccountYearListModel>
    {
        internal AccountYearListMap()
        {
            ToTable("account_years");

            Map(u => u.Id).ToColumn("id").IsKey();
            Map(u => u.YearCode).ToColumn("year_code");
            Map(u => u.YearBegin).ToColumn("year_begin");
            Map(u => u.YearEnd).ToColumn("year_end");
            Map(u => u.IsEnabled).ToColumn("is_enabled");
            // Map(u => u.OrgId).ToColumn("org_id");
        }
    }
}
