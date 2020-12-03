using Dapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

using Fanda2.Backend.Mappings;

using System.Data;

namespace Fanda2.Backend
{
    public class SQLiteDB
    {
        private readonly string ConnectionString;

        static SQLiteDB()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            SqlMapper.AddTypeHandler(new GuidHandler());
            SqlMapper.AddTypeHandler(new TimeSpanHandler());

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new AddressMap());
                config.AddMap(new ContactMap());
                config.AddMap(new OrganizationMap());
                config.AddMap(new OrganizationListMap());
                config.AddMap(new LedgerMap());
                config.AddMap(new LedgerListMap());
                config.AddMap(new BankMap());
                config.AddMap(new PartyMap());
                config.AddMap(new UnitMap());
                config.AddMap(new UnitListMap());
                config.AddMap(new ProductCategoryMap());
                config.AddMap(new ProductCategoryListMap());
                config.AddMap(new ProductMap());
                config.AddMap(new ProductListMap());
                config.AddMap(new AccountYearMap());
                config.AddMap(new AccountYearListMap());
                config.AddMap(new LedgerBalanceMap());

                config.ForDommel();
            });
        }

        internal SQLiteDB()
        {
            string projectPath = System.IO.Path.GetFullPath(@"..\..");
            ConnectionString = $"Data Source={projectPath}\\fanda2.db3;Version=3;Pooling=True;Max Pool Size=100;";
        }

        internal IDbConnection GetConnection()
        {
            var con = new System.Data.SQLite.SQLiteConnection(ConnectionString);
            con.Open();
            return con;
        }
    }
}
