using System;
using System.Data;
using Chloe;
using Chloe.MySql;
using MySql.Data.MySqlClient;
namespace Bll
{
    public class MySqlConnectionFactory : Chloe.Infrastructure.IDbConnectionFactory
    {
        string _connString = null;
        public MySqlConnectionFactory(string connString)
        {
            this._connString = connString;
        }
        public IDbConnection CreateConnection()
        {
            MySqlConnection conn = new MySqlConnection(this._connString);
            return conn;
        }
    }
}