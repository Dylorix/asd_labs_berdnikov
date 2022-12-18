internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Внешняя многофазная сортировка");
        string filename = "data.bin";
        LargeFileGeneration(filename); //Генерируем файл с числами
        Console.WriteLine("До сортировки: ");
        OutputData(filename); //Вывод информации
        DirectMerge dm = new DirectMerge(filename);
        dm.Sort(); //Сортируем
        Console.WriteLine("После сортировки: ");
        OutputData(filename); //Вывод информации

    }

    public static void LargeFileGeneration(string file) //Создание файла с рандомными значениями
    {
        using (var bw = new BinaryWriter(File.Create(file, 65536)))
        {
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                bw.Write(rnd.Next(0, 15));
            }
        }
    }

    public static void OutputData(string file) //Вывод первых 100 значений последовательности
    {
        using (var br = new BinaryReader(File.OpenRead(file)))
        {
            long length = br.BaseStream.Length;
            long position = 0;
            for (int i = 0; i < 100; i++)
            {
                if (position == length)
                {
                    break;
                }
                else
                {
                    Console.Write($"{br.ReadInt32()} ");
                    position += 4;
                }
            }
            Console.WriteLine();
        }
    }

    
}