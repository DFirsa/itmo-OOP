﻿using System;
using MySql.Data.MySqlClient;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client();
            client.addStores();
            client.addProducts();
            client.DeliverShipment();
            client.FindCheapestStoreForProduct();
            client.BuyingOportunity();
            client.buyShipment();
            client.cheapestStore();
        }
    }
}