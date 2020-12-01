using Dapper.FluentMap.Mapping;

using Fanda2.Backend.Database;

using System;
using System.Collections.Generic;
using System.Text;

namespace Fanda2.Backend.Mappings
{
    internal class AddressMap : EntityMap<Address>
    {
        internal AddressMap()
        {
            Map(a => a.AddressLine1).ToColumn("addr_line1");
            Map(a => a.AddressLine2).ToColumn("addr_line2");
            Map(a => a.AddressState).ToColumn("addr_state");
            Map(a => a.PostalCode).ToColumn("postal_code");
        }
    }
}