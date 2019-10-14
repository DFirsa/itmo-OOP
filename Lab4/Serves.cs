using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Lab4
{
    public class Serves: DAO
    {
        private MySqlConnection connection;

        Serves(Management management)
        {
            this.connection = connection;
        }
        
        public void CreateStore(string name)
        {
                connection.Open();
                //check count of stores if not 0 -> warning
                //else -> create store
                var insert = new MySqlCommand($"INSERT INTO storeinfo.stores (name) VALUE ();");
        }

        public void CreateProduct(string productName, string store)
        {
            throw new System.NotImplementedException();
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