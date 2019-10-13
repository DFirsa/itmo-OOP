using System;
using MySql.Data.MySqlClient;

namespace Lab4
{
    public static class DBUtils
    {
        public static class MySQLUtils
        {
            public static MySqlConnection GetDBConnection(string host, int port, string database, string username,
                string password)
            {
                String connString =
                    $"Server={host};Database={database};port={port};User Id={username};password={password}";

                MySqlConnection connection = new MySqlConnection(connString);
                return connection;
            }
        }

        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "StoreInfo";
            string root = "root";
            string password = "qoe74859";

            return MySQLUtils.GetDBConnection(host, port, database, root, password);
        }
    }
}