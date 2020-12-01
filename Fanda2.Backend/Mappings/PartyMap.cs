using Dapper.FluentMap.Mapping;

using Fanda2.Backend.Database;

using System;
using System.Collections.Generic;
using System.Text;

namespace Fanda2.Backend.Mappings
{
    internal class PartyMap : EntityMap<Party>
    {
        internal PartyMap()
        {
            Map(p => p.LedgerId).ToColumn("ledger_id");
            Map(p => p.PaymentTerm).ToColumn("payment_term");
            Map(p => p.CreditLimit).ToColumn("credit_limit");
            Map(p => p.AddressId).ToColumn("address_id");
            Map(p => p.ContactId).ToColumn("contact_id");
        }
    }
}