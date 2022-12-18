using System.Collections;

namespace ConsoleApp1
{
    public class Program
    {
        static void radixsort(int[] Array)
        {
            int n = Array.Length;
            int max = Array[0];

            for (int i = 1; i < n; i++) //Ищем наибольший элемент в массиве
            {
                if (max < Array[i])
                    max = Array[i];
            }

            //Сортировка выполняется на основе места, например, единицы, десятки и так далее.
            for (int place = 1; max / place > 0; place *= 10)
                countingsort(Array, place);
        }

        static void countingsort(int[] Array, int place)
        {
            int n = Array.Length;
            int[] output = new int[n];

            //Диапазон числа составляет 0-9 для каждого рассматриваемого места.
            int[] freq = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < n; i++) //Подсчет количества вхождений в вспомогательынй массив freq
                freq[(Array[i] / place) % 10]++;

            //Меняем count[i] так, чтобы он теперь содержал фактические данные позиции этой цифры в output[]
            for (int i = 1; i < 10; i++)
                freq[i] += freq[i - 1];

            for (int i = n - 1; i >= 0; i--) //"Строим" выходной массив 
            {
                output[freq[(Array[i] / place) % 10] - 1] = Array[i];
                freq[(Array[i] / place) % 10]--;
            }

            //Копируем выходной массив во входной (теперь массив будет содержать отсортированную последовательность, основанный на цифре в указанном месте)
            for (int i = 0; i < n; i++)
                Array[i] = output[i];
        }

        public static void Main()
        {
            int[] arr = { 101, 1, 20, 50, 9, 98, 27, 153, 35, 899 }; //Исходная последовательность

            Console.WriteLine("Поразрядная сортировка");
            radixsort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
}