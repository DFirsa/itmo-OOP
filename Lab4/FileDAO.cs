using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;

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

        private bool haveProduct(string product, int store_id)
        {
            reader = File.OpenText(pathProducts);
            string str;
            bool result = false;
            while ((str = reader.ReadLine()) != null)
            {
                string[] lines = str.Split(':');
                lines[0].Trim();
                lines[1].Trim();
                if (Int32.Parse(lines[0]) == store_id && lines[1].Equals(product.ToLower()))
                {
                    result = true;
                    break;
                }
            }

            reader.Close();
            return result;
        }

        public void CreateProduct(string productName, string store, float price)
        {
            CreateProduct(productName, store, 0, price);
        }

        private void CreateProduct(string productName, string store, int count, float price)
        {
            int storeId = CreateStore(store);
            if (haveProduct(productName, storeId)) return;

            writer = File.AppendText(pathProducts);
            writer.WriteLine($"{storeId} : {productName.ToLower()} : {count} : {price}");
            writer.Close();
        }

        //TODO need to fix
        public void DeliverShipment(List<Shipment> shipments, string store)
        {
            foreach (var shipment in shipments)
            {
                CreateProduct(shipment.product, store, shipment.count, shipment.price);
            }
        }

        private string GetStoreById(int id)
        {
            reader = File.OpenText(pathStores);
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                string[] lines = str.Split(':');
                lines[0].Trim();

                if (Int32.Parse(lines[0]) == id) return lines[1].Trim();
            }

            return null;
        }

        private List<string> GetStoresNamesById(List<int> id)
        {
            List<string> result = new List<string>();
            foreach (var useID in id)
            {
                result.Add(GetStoreById(useID));
            }

            return result;
        }

        public List<string> FindCheapestProductStore(string productName)
        {
            List<string> data = new List<string>();
            reader = File.OpenText(pathProducts);

            string str;
            while ((str = reader.ReadLine()) != null)
            {
                string[] lines = str.Split(':');
                lines[1].Trim();
                if (lines[1].Equals(productName.ToLower()))
                    data.Add($"{GetStoreById(Int32.Parse(lines[0].Trim()))}${lines[1]}");
            }

            reader.Close();

            return data;
        }

        public List<string> GetProductsInfo(string store)
        {
            int storeId = getStoreId(store);
            reader = File.OpenText(pathProducts);
            string str;

            List<string> info = new List<string>();
            while ((str = reader.ReadLine()) != null)
            {
                string[] lines = str.Split(':');
                if (storeId == Int32.Parse(lines[0].Trim()))
                    info.Add($"{lines[1].Trim()}${lines[3].Trim()}${lines[2].Trim()}");
            }

            reader.Close();
            return info;
        }

        public void DecreaseCount(string product, string store, int count)
        {
            int id = getStoreId(store);
            reader = File.OpenText(pathProducts);

            List<string> fileData = new List<string>();

            string str;
            while ((str = reader.ReadLine()) != null)
            {
                string[] lines = str.Split(':');
                lines[0].Trim();
                if (Int32.Parse(lines[0]) == id && lines[1].Trim().Equals(product.ToLower()))
                    fileData.Add(
                        $"{id} : {lines[1].Trim()} : {Int32.Parse(lines[2].Trim()) - count} : {lines[3].Trim()}");
                else fileData.Add(str);
            }
            reader.Close();
            
            writer = new StreamWriter(pathProducts, false);
            foreach (var line in fileData)
            {
                writer.WriteLine(line);
            }
            writer.Close();
        }

        public List<string> GetStoresList()
        {
            List<string> result = new List<string>();
            reader = File.OpenText(pathStores);

            string str;
            while ((str = reader.ReadLine()) != null)
            {
                string[] lines = str.Split(':');
                result.Add(lines[1].Trim());
            }
            reader.Close();
            return result;
        }
    }
}