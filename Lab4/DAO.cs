using System.Collections.Generic;

namespace Lab4
{
    public interface DAO
    {
        void CreateStore(string name);

        void CreateProduct(string productName, string store, float price);

        void DeliverShipment(List<Shipment> shipments, string store);

        List<string> FindCheapestStore(string productName);

        List<string> GetProductsInfo(string store);

        List<string> FindCheapestStore(List<Products> shipment);
        
    }
}