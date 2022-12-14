using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 8, 0, -6, 3, 1, 889, 5 }; //Сортируемая последовательность

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

            Console.WriteLine("Сортировка посредством выбора");
            for (i = 0; i < array.Length; i++) // Распечатываем отсортированный массив
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }
    }
}