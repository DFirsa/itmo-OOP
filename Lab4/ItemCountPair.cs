namespace Lab4
{
    public class ItemCountPair
    {
        protected string itemName { get; set; }
        protected int count { get; set; }

        public ItemCountPair(string itemName, int count)
        {
            this.itemName = itemName;
            this.count = count;
        }
    }
}