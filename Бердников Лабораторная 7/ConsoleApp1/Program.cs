using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Sort(int[] arr)
        {
            int d = arr.Length; //Начинаем с расстояния в длинну последовательности
            while (d >= 1) //Сортируем до тех пор, пока расстояние не станет 1
            {
                for (int i = d; i < arr.Length; ++i)
                {
                    int j = i;
                    while ((j >= d) && (arr[j - d] > arr[j])) //Сравниваем 2 значения на расстоянии d
                    {
                        (arr[j], arr[j - d]) = (arr[j - d], arr[j]); //Меняем их местами
                        j -= d;
                    }
                }
                d /= 2; //Сокращаем расстояние сравнивания в 2 раза
            }
        }
        public static void Main()
        {
            int[] arr = { 12, 11, -5, 0, 6, 34 }; //Сортируемая последовательность

            Console.WriteLine("Сортировка Шелла");
            Sort(arr);

            for (int i = 0; i < arr.Length; i++) //Печать отсортированной последовательности
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
}