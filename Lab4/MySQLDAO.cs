using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Lab4
{
    public class MySQLDAO : DAO
    {
        private MySqlConnection connection;

        public MySQLDAO(string host, int port, string database, string username, string password)
        {
            this.connection =
                new MySqlConnection(
                    $"Server={host}; Database={database}; Port={port}; User Id={username}; Password={password}");
            
            connection.Open();
        }

        ~MySQLDAO()
        {
            connection.Close();
        }

        bool haveSomething(string command)
        {
            MySqlCommand sqlCommand = new MySqlCommand(command, connection);
            int count = Int32.Parse(sqlCommand.ExecuteScalar().ToString());

            return count != 0;
        }

        public void CreateStore(string name)
        {
            if (!haveSomething($"SELECT COUNT(name) FROM storeinfo.stores WHERE name = {name}"))
            {
                string command = $"INSERT INTO storeinfo.stores (name) VALUE('{name}') ";
                MySqlCommand sqlCommand = new MySqlCommand(command, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void CreateProduct(string productName, string store)
        {
        }

        public void DeliverShipment(List<ShipmentProduct> shipment)
        {
            throw new System.NotImplementedException();
        }

        public List<string> FindCheapestStore(string productName)
        {
            throw new System.NotImplementedException();
        }

        public List<ItemCountPair> CanBuy(int moneySum)
        {
            throw new System.NotImplementedException();
        }

        public float BuyShipment(List<ItemCountPair> shipment)
        {
            throw new System.NotImplementedException();
        }

        public List<string> FindCheapestStore(List<ItemCountPair> shipment)
        {
            throw new System.NotImplementedException();
        }
    }
}