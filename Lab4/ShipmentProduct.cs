namespace Lab4
{
    public class ShipmentProduct: ItemCountPair
    {
        private float price { get; }

        public ShipmentProduct(string itemName, int count, float price) : base(itemName, count)
        {
            this.itemName = itemName;
            this.count = count;
            this.price = price;
        }
    }
}