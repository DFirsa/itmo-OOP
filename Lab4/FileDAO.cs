using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    public class FileDAO
    {
        private StreamWriter writer;
        private StreamReader reader;
        private string pathStores;
        private string pathProducts;

        private int id = 0;

        public FileDAO(string fileNameStores, string fileNamePathProducts)
        {
            pathStores = $"..\\{fileNameStores}";
            pathProducts = $"..\\{fileNamePathProducts}";
        }

        private int getStoreId(string name)
        {
            int id = -1;
            reader = File.OpenText(pathStores);
            string line;
            
            while ((line = reader.ReadLine()) != null)
            {
                string[] lines = line.Split(':');
                lines[2].Trim();
                if (lines[2].Equals(name.ToLower())) id = Int32.Parse(lines[1]);
            }
            
            reader.Close();
            return id;
        }

        public int CreateStore(string name)
        {
            int sId = getStoreId(pathStores);
            writer = File.AppendText(pathStores);
            if (sId == -1)
            {
                writer.WriteLine($"{id} : {name.ToLower()}");
                sId = id;
                id++;
            }
            writer.Close();
            return sId;
        }

        public void CreateProduct(string productName, string store, float price)
        {
            int storeId = CreateStore(store);
            
            
        }

        public void DeliverShipment(List<Shipment> shipments, string store)
        {
            throw new System.NotImplementedException();
        }

        public List<string> FindCheapestProductStore(string productName)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetProductsInfo(string store)
        {
            throw new System.NotImplementedException();
        }

        public void DecreaseCount(string product, string store, int count)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetStoresList()
        {
            throw new System.NotImplementedException();
        }
    }
}