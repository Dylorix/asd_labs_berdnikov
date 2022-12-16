namespace ConsoleApp1
{
    public class Program
    {
        public static int[] SortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex; //Индекс с какого начинаем сортировку
            var j = rightIndex; //Индекс на каком заканчиваем сортировку
            var pivot = array[leftIndex]; //Значение, которое делит последовательность

            while (i <= j)
            {
                while (array[i] < pivot) //Если слева от значения числа меньше его, не трогаем
                {
                    i++;
                }

                while (array[j] > pivot) //Если справа от значения числа больше его, не трогаем
                {
                    j--;
                }

                if (i <= j) //Если мы находим элемент в левом подмассиве, который больше значения, и элемент в правом подмассиве, который меньше значения, мы меняем их местами
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++; //Обновляем счётчики подмассивов
                    j--;
                }
            }

            //Так как сортирока рекурсивна, делаем те же действия для получившихся подпоследовательностей слева и справа:
            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);

            return array; //Возвращаем отсортированную последовательность
        }

        public static void Main()
        {
            int[] arr = { 12, 11, -5, 0, 6, 34 }; //Исходная последовательность

            Console.WriteLine("Быстрая сортировка");
            SortArray(arr,0,arr.Length-1);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
}