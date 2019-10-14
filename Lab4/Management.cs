using System;
using MySql.Data.MySqlClient;

namespace Lab4
{
    public class Management
    {

        private MySqlConnection DBConnection { get; }

        public Management(string host, int port, string database, string username, string password)
        {
            String connString =
                $"Server={host};Database={database};port={port};User Id={username};password={password}";

            DBConnection = new MySqlConnection(connString);
        }
        
        
    }
}