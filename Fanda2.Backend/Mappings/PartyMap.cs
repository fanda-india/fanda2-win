using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;

namespace Fanda2.Backend.Mappings
{
    internal class PartyMap : DommelEntityMap<Party>
    {
        internal PartyMap()
        {
            ToTable("parties");

            Map(p => p.LedgerId).ToColumn("ledger_id").IsKey();
            Map(o => o.RegdNum).ToColumn("regd_num");
            Map(o => o.PAN).ToColumn("party_pan");
            Map(o => o.TAN).ToColumn("party_tan");
            Map(o => o.GSTIN).ToColumn("gstin");
            Map(p => p.PaymentTerm).ToColumn("payment_term");
            Map(p => p.CreditLimit).ToColumn("credit_limit");
            Map(p => p.AddressId).ToColumn("address_id");
            Map(p => p.ContactId).ToColumn("contact_id");
        }
    }
}