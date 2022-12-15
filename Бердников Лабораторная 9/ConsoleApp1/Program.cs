using System;

namespace ConsoleApp1
{
    public class HeapSort
    {
        public static void Sort(int[] arr)
        {
            for (int i = (arr.Length / 2) - 1; i >= 0; i--) //Создаём кучу
            {
                Heapify(arr, arr.Length, i);
            }

            for (int j = arr.Length - 1; j >= 1; j--) //Меняем значения первого элемента с последним и делаем еще раз прогонку
            {
                (arr[0], arr[j]) = (arr[j], arr[0]);
                Heapify(arr, j, 0);
            }
        }
        public static void Heapify(int[] arr, int length, int position) //length - длина массива, position - позиция, где мы будем "сортировать"
        {
            int current = position;
            int left = (2 * current) + 1;
            int right = (2 * current) + 2;
            if (left < length && arr[current] < arr[left]) //Если левый элемент не выходит за рамки и потомок больше, чем родитель, то фиксируем его индекс
            {
                current = left;
            }
            if (right < length && arr[current] < arr[right]) //Аналогично с правым
            {
                current = right;
            }
            if (current != position) //Если мы нашли потомка, у которого значение больше, то меняем их местами и запускаем цикл снова
            {
                (arr[position], arr[current]) = (arr[current], arr[position]);
                Heapify(arr, length, current);
            }
        }

        public static void Main()
        {
            int[] arr = { 12, 11, -5, 0, 6, 34 }; //Сортируемая последовательность

            Console.WriteLine("Пирамидальная сортировка");
            Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
}