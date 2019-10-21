using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Lab4
{
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
            line.Substring(0, line.IndexOf('$')).Trim();
            return Char.ToUpper(line[0]) + line.Substring(1).ToLower();
        }

        string ToDBFormat(string line)
        {
            return line.ToLower();
        }

        public void createStore(string store)
        {
            sqlDao.CreateStore(store);
        }

        public void CreateProduct(string store, string product, float price)
        {
            sqlDao.CreateProduct(product, store, price);
        }

        public void DeliverShipment(List<Shipment> shipments, string store)
        {
            sqlDao.DeliverShipment(shipments, store);
        }

        public List<string> FindCheapestProductStore(string product)
        {
            List<string> prices = sqlDao.FindCheapestProductStore(product);
            List<string> cheapestStore = new List<string>();

            List<float> ShopPrice = new List<float>();
            foreach (var pair in prices)
            {
                string[] str = pair.Split('$');
                ShopPrice.Add(float.Parse(str[1]));
            }

            float minPrice = ShopPrice.Min();

            for (int i = 0; i < prices.Count; i++)
            {
                if (minPrice == ShopPrice[i])
                    cheapestStore.Add(ToFormat(prices[i]));
            }

            return cheapestStore;
        }

        public List<Products> GetCountProducts(float sum, string store)
        {
            sqlDao.GetProductsInfo(store);
        }
    }
}