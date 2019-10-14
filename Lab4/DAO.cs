using System.Collections.Generic;

namespace Lab4
{
    public interface DAO
    {
        void CreateStore(string name);

        void CreateProduct(string productName, string store);

        void DeliverShipment(List<ShipmentProduct> shipment);

        List<string> FindCheapestStore(string productName);

        List<ItemCountPair> CanBuy(int moneySum);

        float BuyShipment(List<ItemCountPair> shipment);

        List<string> FindCheapestStore(List<ItemCountPair> shipment);
        
    }
}