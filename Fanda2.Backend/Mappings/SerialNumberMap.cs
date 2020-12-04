using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;

namespace Fanda2.Backend.Mappings
{
    internal class SerialNumberMap : DommelEntityMap<SerialNumber>
    {
        internal SerialNumberMap()
        {
            ToTable("serial_numbers");

            Map(sn => sn.Id).ToColumn("id").IsKey();
            Map(sn => sn.YearId).ToColumn("year_id");
            Map(sn => sn.SerialModule).ToColumn("serial_module");
            Map(sn => sn.SerialPrefix).ToColumn("serial_prefix");
            Map(sn => sn.SerialFormat).ToColumn("serial_format");
            Map(sn => sn.SerialSuffix).ToColumn("serial_suffix");
            Map(sn => sn.LastSerial).ToColumn("last_serial");
            Map(sn => sn.LastNumber).ToColumn("last_number");
            Map(sn => sn.LastDate).ToColumn("last_date");
            Map(sn => sn.SerialReset).ToColumn("serial_reset");
        }
    }
}
