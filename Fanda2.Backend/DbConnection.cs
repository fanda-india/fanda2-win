using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Fanda2.Backend
{
    internal class DbConnection
    {
        private readonly string ConnectionString;

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
