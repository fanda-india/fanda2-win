using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;

namespace Fanda2.Backend.Mappings
{
    internal class ContactMap : DommelEntityMap<Contact>
    {
        internal ContactMap()
        {
            ToTable("contacts");

            Map(c => c.Id).IsKey();
            Map(c => c.Salutation).ToColumn("salutation");
            Map(c => c.FirstName).ToColumn("first_name");
            Map(c => c.LastName).ToColumn("last_name");
            Map(c => c.Designation).ToColumn("designation");
            Map(c => c.Department).ToColumn("department");
            Map(c => c.Email).ToColumn("email");
            Map(c => c.WorkPhone).ToColumn("work_phone");
            Map(c => c.MobileNumber).ToColumn("mobile_number");
        }
    }
}
