namespace Lab4
{
    public class Products
    {
        public readonly string product;
        public readonly int count;

        public Products(string product, int count, float price)
        {
            this.product = product;
            this.count = count;
        }
    }

    public struct Shipment
    {
        public readonly string product;
        public readonly int count;
        public readonly float price;

        public Shipment(string product, int count, float price)
        {
            this.product = product;
            this.count = count;
            this.price = price;
        }
    }
}