namespace ConsoleApp1
{
    internal class Item<T>
    {
        public int Key { get; set; }
        public List<T> Nodes { get; set; }
        public Item(int key)
        {
            this.Key = key;
            this.Nodes = new List<T>();
        }

    }
}
