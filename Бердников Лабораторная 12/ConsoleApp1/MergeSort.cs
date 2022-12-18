public class DirectMerge
{
    public string FileInput { get; set; }
    private long iterations, segments;
    int a = 0;

    public DirectMerge(string input)
    {
        FileInput = input;
        iterations = 1; //Степень двойки (количество элементов в каждой последовательности)
    }

    public void Sort()
    {
        while (true)
        {
            SplitToFiles();
            //Если массив отсортирован, то завершаем работу
            if (segments == 1)
            {
                break;
            }
            MergePairs();
        }
        Console.WriteLine();
    }

    private void SplitToFiles() //Разделяем на 2 вспомогательных файла
    {

        segments = 1;
        using (BinaryReader br = new BinaryReader(File.OpenRead(FileInput)))
        using (BinaryWriter writerA = new BinaryWriter(File.Create("a.bin", 65536)))
        using (BinaryWriter writerB = new BinaryWriter(File.Create("b.bin", 65536)))
        {
            long counter = 0;
            bool flag = true; //Записываем либо в первый, либо во второй файл

            long length = br.BaseStream.Length;
            long position = 0;
            while (position != length)
            {
                //Если мы достигли количества элементов в последовательности, то меняем флаг на следующий файл (и обнуляем счетчик количества)
                if (counter == iterations)
                {
                    flag = !flag;
                    counter = 0;
                    segments++;
                }

                int element = br.ReadInt32();
                position += 4;
                if (flag)
                {
                    writerA.Write(element);
                }
                else
                {
                    writerB.Write(element);
                }
                counter++;
            }
        }
    }

    private void MergePairs() //Слияние отсортированных последовательностей обратно в единый файл
    {
        using (BinaryReader readerA = new BinaryReader(File.OpenRead("a.bin")))
        using (BinaryReader readerB = new BinaryReader(File.OpenRead("b.bin")))
        using (BinaryWriter bw = new BinaryWriter(File.Create(FileInput, 65536)))
        {
            long counterA = iterations, counterB = iterations;
            int elementA = 0, elementB = 0;
            bool pickedA = false, pickedB = false, endA = false, endB = false;
            long lengthA = readerA.BaseStream.Length;
            long lengthB = readerB.BaseStream.Length;
            long positionA = 0;
            long positionB = 0;
            while (!endA || !endB)
            {
                if (counterA == 0 && counterB == 0)
                {
                    counterA = iterations;
                    counterB = iterations;
                }

                if (positionA != lengthA)
                {
                    if (counterA > 0 && !pickedA)
                    {
                        elementA = readerA.ReadInt32();
                        positionA += 4;
                        pickedA = true;
                    }
                }
                else
                {
                    endA = true;
                }

                if (positionB != lengthB)
                {
                    if (counterB > 0 && !pickedB)
                    {
                        elementB = readerB.ReadInt32();
                        positionB += 4;
                        pickedB = true;
                    }
                }
                else
                {
                    endB = true;
                }

                if (pickedA)
                {
                    if (pickedB)
                    {
                        if (elementA < elementB)
                        {
                            bw.Write(elementA);
                            counterA--;
                            pickedA = false;
                        }
                        else
                        {
                            bw.Write(elementB);
                            counterB--;
                            pickedB = false;
                        }
                    }
                    else
                    {
                        bw.Write(elementA);
                        counterA--;
                        pickedA = false;
                    }
                }
                else if (pickedB)
                {
                    bw.Write(elementB);
                    counterB--;
                    pickedB = false;
                }
            }

            iterations *= 2; //Увеличиваем размер серии в 2 раза
        }
        
        Console.WriteLine("a"); //Вывод a
        using (var br = new BinaryReader(File.OpenRead("a.bin")))
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
        Console.WriteLine("b"); //Вывод b
        using (var br = new BinaryReader(File.OpenRead("b.bin")))
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
        Console.WriteLine("Основной файл"); //Вывод основного файла
        using (var br = new BinaryReader(File.OpenRead(FileInput)))
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