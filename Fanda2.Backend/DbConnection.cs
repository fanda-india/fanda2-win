using Dapper;
using Dapper.FluentMap;

using Fanda2.Backend.Database;
using Fanda2.Backend.Mappings;

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Fanda2.Backend
{
    internal class DbConnection
    {
        private readonly string ConnectionString;

        static DbConnection()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            SqlMapper.AddTypeHandler(new GuidHandler());
            SqlMapper.AddTypeHandler(new TimeSpanHandler());

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new AddressMap());
                config.AddMap(new ContactMap());
                config.AddMap(new OrganizationMap());
                config.AddMap(new LedgerMap());
                config.AddMap(new LedgerListMap());
                config.AddMap(new BankMap());
                config.AddMap(new PartyMap());
            });
        }

        public DbConnection()
        {
            string projectPath = System.IO.Path.GetFullPath(@"..\..\");
            ConnectionString = $"Data Source={projectPath}\\fanda2.db3;Version=3;Pooling=True;Max Pool Size=100;";
        }

        public IDbConnection GetConnection()
        {
            var con = new System.Data.SQLite.SQLiteConnection(ConnectionString);
            con.Open();
            return con;
        }
    }
}