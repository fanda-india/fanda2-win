using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;

namespace Fanda2.Backend.Mappings
{
    internal class AddressMap : DommelEntityMap<Address>
    {
        internal AddressMap()
        {
            ToTable("addresses");

            Map(a => a.Id).IsKey();
            Map(a => a.Attention).ToColumn("attention");
            Map(a => a.AddressLine1).ToColumn("addr_line1");
            Map(a => a.AddressLine2).ToColumn("addr_line2");
            Map(a => a.City).ToColumn("city");
            Map(a => a.AddressState).ToColumn("addr_state");
            Map(a => a.Country).ToColumn("country");
            Map(a => a.PostalCode).ToColumn("postal_code");
            Map(a => a.Phone).ToColumn("phone");
            Map(a => a.Fax).ToColumn("fax");
        }
    }
}
