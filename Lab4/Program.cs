using System;
using MySql.Data.MySqlClient;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client();
            client.addStores();
        }
    }
}