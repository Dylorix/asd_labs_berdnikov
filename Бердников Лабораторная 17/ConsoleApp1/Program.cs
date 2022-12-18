namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bt = new BinaryTrees(8, null); //Добавляем значения в бинарное дерево
            bt.Add(3);
            bt.Add(1);
            bt.Add(5);
            bt.Menu(); //Вызов меню для действий над деревом
        }
    }
}