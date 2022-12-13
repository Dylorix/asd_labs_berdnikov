using System;

namespace ConsoleApp1
{
    class CombSort
    {
        static int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13; //Значение расстояния следующего прыжка получаеми делением на 1.3 предыдущего
            if (gap < 1) //Но не меньше 1
            {
                return 1;
            }
            return gap;
        }

        static void Sort(int[] array) //Сортировка прочёсыванием
        {
            int length = array.Length;

            int gap = length; //Изначальное расстояние прохода - длинна последовательности

            bool swapped = true; //Берём значение true, чтобы войти в цикл

            while (gap != 1 || swapped == true)
            {
                gap = GetNextGap(gap); //Уменьшаем расстояние

                swapped = false; //Временно ставим false, пока не обменяем два значения местами (когда всё обменяем, выйдем с цикла)

                for (int i = 0; i < length - gap; i++) //Сравниваем все значения с данным расстоянием
                {
                    if (array[i] > array[i + gap])
                    {
                        int temp = array[i]; //Сам обмен
                        array[i] = array[i + gap];
                        array[i + gap] = temp;

                        swapped = true; //И снова в цикл
                    }
                }
            }
        }

        public static void Main()
        {
            int[] array = {-10, 28, 1, 55, 6, -21, 36, 3, 45, 15, 0};

            Console.WriteLine("Сортировка методом прочёсывания:");
            Sort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }
    }
}