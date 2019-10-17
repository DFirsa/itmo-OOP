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

        int getStoreId(string store)
        {
            string command = $"SELECT id FROM store.info WHERE name = '{store}'";
            MySqlCommand sqlCommand = new MySqlCommand(command, connection);

            return Int32.Parse(sqlCommand.ExecuteScalar().ToString());
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

        public void CreateProduct(string productName, string store, float price)
        {
            if (!haveSomething($"SELECT COUNT(name) FROM storeinfo.stores WHERE name = '{store}'"))
            {
                CreateStore(store);
                CreateProduct(productName, store, price);
            }
            else
            {
                int id = getStoreId(store);
                string command =
                    $"INSERT INTO storeinfo.products (name, store_id, number, price) VALUES ('{productName}', {id}, 0, {price})";
                
                MySqlCommand sqlCommand = new MySqlCommand(command, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeliverShipment(List<ShipmentProduct> shipment)
        {
            foreach (var shipmentProduct in shipment)
            {
                if (!haveSomething($"SELECT COUNT (id) FROM storeinfo.products WHERE "))
                {
                    //todo dopisat'
                }
            }
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