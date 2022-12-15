using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Sort (int[] array)
        {
            int i, j, min, temp;
            for (i = 0; i < array.Length - 1; i++)
            {
                min = i; //Устанавливаем начальное значение минимального индекса

                for (j = i + 1; j < array.Length; j++) //Находим индекс минимального элемента
                {
                    if (array[j] < array[min])
                        min = j;
                }

                temp = array[i]; //Меняем значения старого мнимума и текущего местами
                array[i] = array[min];
                array[min] = temp;
            }
        }
        
        static void Main(string[] args)
        {

            int[] array = { 12, 11, -5, 0, 6, 34 }; //Сортируемая последовательность
            Sort(array);
            Console.WriteLine("Сортировка посредством выбора");

            for (int i = 0; i < array.Length; i++) // Распечатываем отсортированный массив
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }
    }
}