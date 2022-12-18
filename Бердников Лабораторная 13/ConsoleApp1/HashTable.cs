namespace ConsoleApp1
{
    internal class HashTable<T>
    {
        public Item<T>[] items;

        public HashTable(int size) //Создание самой таблицы
        {
            items = new Item<T>[size];
            for (int i = 0; i < items.Length; ++i)
            {
                items[i] = new Item<T>(i);
            }
        }
        public void Add(T item) //Функция добавления пары
        {
            var key = GetHash(item);
            
            items[key].Nodes.Add(item);
        }
        public bool Search(T item) //Функция поиска пары
        {
            var key = GetHash(item);
            return items[key].Nodes.Contains(item);
        }
        private int GetHash(T item) //Функция получения пары (нужна для работы 2х функций сверху)
        {
            return Math.Abs(item.GetHashCode() % items.Length); //Находим значение по ключу
        }
    }
}