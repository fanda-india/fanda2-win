using Dapper.FluentMap.Mapping;

using Fanda2.Backend.Database;

using System;
using System.Collections.Generic;
using System.Text;

namespace Fanda2.Backend.Mappings
{
    internal class ContactMap : EntityMap<Contact>
    {
        internal ContactMap()
        {
            Map(c => c.FirstName).ToColumn("first_name");
            Map(c => c.LastName).ToColumn("last_name");
            Map(c => c.WorkPhone).ToColumn("work_phone");
            Map(c => c.MobileNumber).ToColumn("mobile_number");
        }
    }
}