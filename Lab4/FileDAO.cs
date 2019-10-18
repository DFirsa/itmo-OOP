using System.Collections.Generic;

namespace Lab4
{
    public class FileDAO: DAO
    {
        public void CreateStore(string name)
        {
            throw new System.NotImplementedException();
        }

        public void CreateProduct(string productName, string store, float price)
        {
            throw new System.NotImplementedException();
        }

        public void DeliverShipment(List<Shipment> shipments, string store)
        {
            throw new System.NotImplementedException();
        }

        public List<string> FindCheapestStore(string productName)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetProductsInfo(string store)
        {
            throw new System.NotImplementedException();
        }

        public List<string> FindCheapestStore(List<Products> shipment)
        {
            throw new System.NotImplementedException();
        }
    }
}