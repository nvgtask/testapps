using System;
using System.Data.SQLite;

namespace WebApplication1.Frame.DataAccess
{
    public class SQLiteDataProvider : IDisposable
    {
        private readonly SQLiteConnection _dbConnection;

        public SQLiteDataProvider()
        {
            _dbConnection = new SQLiteConnection(@"Data Source=C:\nvgtask\testapps\WebApplication1\App_Data\MyDatabase.sqlite;Version=3;");
            _dbConnection.Open();
        }

        public SQLiteCommand GetCommand(string sql)
        {
            return new SQLiteCommand(sql, _dbConnection);
        }

        public void ExecuteNonQuery(string sql)
        {
            GetCommand(sql).ExecuteNonQuery();
        }

        public int ExecuteQuery(string sql)
        {
            int rowCount = GetCommand(sql).ExecuteNonQuery();
            return rowCount;
        }

        public void Dispose()
        {
            _dbConnection.Close();
        }
    }
}