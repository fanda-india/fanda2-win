using Dapper.FluentMap.Mapping;

using Fanda2.Backend.Database;

using System;
using System.Collections.Generic;
using System.Text;

namespace Fanda2.Backend.Mappings
{
    internal class BankMap : EntityMap<Bank>
    {
        internal BankMap()
        {
            Map(b => b.LedgerId).ToColumn("ledger_id");
            Map(b => b.AccountNumber).ToColumn("account_number");
            Map(b => b.AccountType).ToColumn("account_type");
            Map(b => b.IfscCode).ToColumn("ifsc_code");
            Map(b => b.MicrCode).ToColumn("micr_code");
            Map(b => b.BranchCode).ToColumn("branch_code");
            Map(b => b.BranchName).ToColumn("branch_name");
            Map(b => b.AddressId).ToColumn("address_id");
            Map(b => b.ContactId).ToColumn("contact_id");
            Map(b => b.IsDefault).ToColumn("is_default");
        }
    }
}