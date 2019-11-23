using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var storage = ConfigurationManager.AppSettings.Get("storage");
            Client client = new Client(storage == "database");
            client.addStores();
            client.addProducts();
            client.DeliverShipment();
        }
    }
}