namespace HashTable
{
    internal class HashTable
    {
        public Dictionary<int, string> dictionary; //Словарь
        Random random; //Рандом
        public HashTable()
        {
            dictionary = new Dictionary<int, string>();
            random = new Random();
        }
        public void Add(string data) //Функция добавления пары
        {
            if (dictionary.ContainsValue(data)) //Если уже есть в словаре, не добавляем
            {
                return;
            }
            int key = GetHash(data);
            while (dictionary.ContainsKey(key))
            {
                key = GetHash(data);
            }
            
            dictionary.Add(key, data);
        }

        public string Search(string data) //Функция поиска пары
        {
            int key = GetHash(data);
            if (dictionary.ContainsKey(key))
            {
                return data;
            }
            return null;
        }

        public int GetHash(string data) //Функция получения пары (нужна для работы 2х функций сверху)
        {
            return (data.GetHashCode() + random.Next(1000)) % 1000; //Находим значение по ключу
        }
    }
}
