namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bt = new BinaryTrees(8, null); //Добавляем значения в бинарное дерево
            bt.Add(3);
            bt.Add(1);
            bt.Add(6);
            bt.Add(4);
            bt.Add(7);
            bt.Add(10);
            bt.Add(14);
            bt.Add(13);
            bt.Add(9);
            string str = string.Empty;
            BinaryTrees.ByPassing(bt,ref str); //Прямой обход
            Console.WriteLine(str); //Его вывод
            str = string.Empty;
            BinaryTrees.ByPassing2(bt,ref str); //Центральный обход
            Console.WriteLine(str); //Его вывод
            str = string.Empty;
            BinaryTrees.ByPassing3(bt,ref str); //Концевой обход
            Console.WriteLine(str); //Его вывод
            bt.print(); //Вывод линейно-скобочной записи
        }
    }
}