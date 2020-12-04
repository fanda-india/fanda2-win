using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;

namespace Fanda2.Backend.Mappings
{
    internal class LedgerBalanceMap : DommelEntityMap<LedgerBalance>
    {
        internal LedgerBalanceMap()
        {
            ToTable("ledger_balances");

            Map(a => a.Id).ToColumn("id").IsKey();
            Map(a => a.LedgerId).ToColumn("ledger_id");
            Map(a => a.YearId).ToColumn("year_id");
            Map(a => a.OpeningBalance).ToColumn("opening_balance");
            Map(a => a.BalanceSign).ToColumn("balance_sign");
        }
    }
}