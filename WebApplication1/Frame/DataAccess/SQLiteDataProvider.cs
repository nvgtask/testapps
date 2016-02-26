using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace WebApplication1.Frame.DataAccess
{
    public class SQLiteDataProvider : IDisposable
    {
        private SQLiteConnection dbConnection;

        public SQLiteDataProvider()
        {
            dbConnection = new SQLiteConnection(@"Data Source=C:\is24exam\testapps\WebApplication1\App_Data\MyDatabase.sqlite;Version=3;");
            dbConnection.Open();
        }

        public SQLiteCommand GetCommand(string sql)
        {
            return new SQLiteCommand(sql, dbConnection);
        }

        public void ExecuteNonQuery(string sql)
        {
            GetCommand(sql).ExecuteNonQuery();
        }

        public void Dispose()
        {
            dbConnection.Close();
        }
    }
}