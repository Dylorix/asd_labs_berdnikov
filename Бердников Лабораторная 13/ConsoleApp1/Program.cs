namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> slova = new List<string>(); //Создаём место для слов
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                while (!sr.EndOfStream) //Пока не конец
                {
                    slova.Add(sr.ReadLine()); //Добавляем слова
                }
            }
            string str = string.Empty;
            for (int i = 0; i < slova.Count; ++i)
            {
                str += slova[i];
            }
            string[] strs;
            strs = str.Split(" ");
            var table = new HashTable<string>(10); //Создаём хеш-таблцу
            foreach (var item in strs) //Добавляем слова в эту таблицу
            {
                table.Add(item);
            }
        }
    }
}