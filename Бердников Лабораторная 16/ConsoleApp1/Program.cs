namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bt = new BinaryTrees(8, null); //Добавляем значения в бинарное дерево
            bt.Add(5);
            bt.Add(3);
            bt.Add(7);
            bt.Add(13);
            bt.Add(12);
            bt.Add(17);
            bt.Add(15);
            bt.Add(16);
            bt.Add(19);
            string str = string.Empty;
            bt.ByPassing(bt,ref str); //Нерекурсивный прямой обход
            Console.WriteLine(str); //Его вывод

            bt.print(); //Вывод линейно-скобочной записи
        }
    }
}