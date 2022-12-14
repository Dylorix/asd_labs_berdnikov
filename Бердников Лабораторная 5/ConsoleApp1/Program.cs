using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Sort(int[] arr) //Сортировка вставками
        {
            for (int i = 1; i < arr.Length; ++i) //Цикл наращивания количества сортируемых чисел
            {
                int min = arr[i]; //Последнее (сортируемое) значение
                int j = i; //Указатель на его индекс
                while (j > 0 && arr[j - 1] > min) //Сдвигаем все числа до текущего
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = min; //И меняем оставшиеся значения местами
            }
        }
        public static void Main()
        {
            int[] arr = {12, 11, -5, 0, 6, 34};

            Console.WriteLine("Cортировка вставками");
            Sort(arr);

            for (int i = 0; i < arr.Length; i++) //Вывод отсортированной последовательности
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
}