﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Lab4
{
    public struct Pair
    {
        public readonly float price;
        public readonly string store;

        public Pair(float price, string store)
        {
            this.price = price;
            this.store = store;
        }
    }
    public class Serves
    {
        private MySQLDAO sqlDao;
//        private FileDAO fileDao;

        public Serves()
        {
            sqlDao = new MySQLDAO("localhost", 3306, "StoreInfo", "root", "qoe74859");
        }

        string ToFormat(string line)
        {
            line.Trim();
            return Char.ToUpper(line[0]) + line.Substring(1).ToLower();
        }

        string ToDBFormat(string line)
        {
            return line.ToLower();
        }

        Shipment GetShipment(List<string> storeInfo, string productName)
        {
            Shipment shipment = null;
            
            foreach (var info in storeInfo)
            {
                string[] data = info.Split('$');
                if (ToFormat(data[0]).Equals(ToFormat(productName)))
                {
                    float price = float.Parse(data[1]);
                    int count = Int32.Parse(data[2]);
                    
                    shipment = new Shipment(data[0], count, price);
                    break;
                }
            }

            return shipment;
        }

        public void createStore(string store)
        {
            sqlDao.CreateStore(ToDBFormat(store));
        }

        public void CreateProduct(string store, string product, float price)
        {
            sqlDao.CreateProduct(ToDBFormat(product), ToDBFormat(store), price);
        }

        public void DeliverShipment(List<Shipment> shipments, string store)
        {
            sqlDao.DeliverShipment(shipments, ToDBFormat(store));
        }

        public List<string> FindCheapestProductStores(string product)
        {
            List<string> prices = sqlDao.FindCheapestProductStore(product);
            List<string> cheapestStore = new List<string>();

            List<float> shopPrice = new List<float>();
            foreach (var pair in prices)
            {
                string[] str = pair.Split('$');
                shopPrice.Add(float.Parse(str[1]));
            }

            float minPrice = shopPrice.Min();

            for (int i = 0; i < prices.Count; i++)
            {
                string[] info = prices[i].Split('$');
                if (minPrice == shopPrice[i])
                    cheapestStore.Add(ToFormat(info[0]));
            }

            return cheapestStore;
        }

        public List<Products> GetCountProducts(float sum, string store)
        {
            List<string> sqlInfo = sqlDao.GetProductsInfo(store);
            List<Products> products = new List<Products>();

            foreach (var line in sqlInfo)
            {
                string[] infoSet = line.Split('$');
                float price = float.Parse(infoSet[1].Trim());
                string product = ToFormat(infoSet[0]);

                int count = (int) Math.Floor(sum / price);

                if (count > 0) products.Add(new Products(product, count));
            }
            
//                if (products.Count == 0) exception
            return products;
        }

        public float BuyShipment(List<Products> shipment, string store)
        {
            List<string> productsInfo = sqlDao.GetProductsInfo(ToDBFormat(store));
            float sum = 0;

            List<int> productBought = new List<int>();

            foreach (var product in shipment)
            {
                Shipment productInfo = GetShipment(productsInfo, product.Product);
//                if (productInfo == null) exception

//                if (productInfo.count < product.Count) exception

                sum += productInfo.price * product.Count;
                productBought.Add(product.Count);
            }

            for (int i = 0; i < shipment.Count; i++)
                sqlDao.DecreaseCount(ToDBFormat(shipment[i].Product), ToDBFormat(store), productBought[i]);

            return sum;
        }

        public List<string> FindCheapestStores(List<Products> shipment)
        {
            List<string> stores = sqlDao.GetStoresList();
            List<Pair> pairs = new List<Pair>();
                
            foreach (var store in stores)
            {
                try
                {
                    pairs.Add(new Pair(BuyShipment(shipment, store), store));
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            
            List<float> prices = new List<float>();
            foreach (var price in pairs) prices.Add(price.price); 

            float minSum = prices.Min();
            List<string> result = new List<string>();
            foreach (var pair in pairs)
            {
                if (pair.price == minSum) result.Add(ToFormat(pair.store));
            }

//            if (result.Count == 0) exception

            return result;
        }
    }
}