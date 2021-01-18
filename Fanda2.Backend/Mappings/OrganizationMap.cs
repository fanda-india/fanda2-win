using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

namespace Fanda2.Backend.Mappings
{
    internal class OrganizationMap : DommelEntityMap<Organization>
    {
        internal OrganizationMap()
        {
            ToTable("organizations");

            Map(o => o.Id).ToColumn("id").IsKey();
            Map(o => o.Code).ToColumn("code");
            Map(o => o.OrgName).ToColumn("org_name");
            Map(o => o.OrgDesc).ToColumn("org_desc");
            Map(o => o.RegdNum).ToColumn("regd_num");
            Map(o => o.PAN).ToColumn("org_pan");
            Map(o => o.TAN).ToColumn("org_tan");
            Map(o => o.GSTIN).ToColumn("gstin");
            Map(o => o.AddressId).ToColumn("address_id");
            Map(o => o.ContactId).ToColumn("contact_id");
            Map(o => o.ActiveYearId).ToColumn("active_year_id");
            Map(o => o.IsEnabled).ToColumn("is_enabled");
            Map(o => o.CreatedAt).ToColumn("created_at");
            Map(o => o.UpdatedAt).ToColumn("updated_at");
        }
    }

    internal class OrganizationListMap : DommelEntityMap<OrganizationListModel>
    {
        internal OrganizationListMap()
        {
            ToTable("organizations");
            Map(o => o.Id).ToColumn("id").IsKey();
            Map(l => l.Code).ToColumn("code");
            Map(l => l.OrgName).ToColumn("org_name");
            Map(l => l.OrgDesc).ToColumn("org_desc");
            Map(l => l.ActiveYearId).ToColumn("active_year_id");
            Map(l => l.IsEnabled).ToColumn("is_enabled");
        }
    }
}
