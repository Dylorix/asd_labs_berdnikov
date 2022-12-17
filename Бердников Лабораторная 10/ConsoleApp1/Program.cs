namespace ConsoleApp1
{
    public class Program
    {
        static public void Merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid]) //Если числа слева больше, чем справа
                    temp[tmp_pos++] = numbers[left++]; //То во временный массив ставим левое значение
                else
                    temp[tmp_pos++] = numbers[mid++]; //Иначе правное
            }
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
            for (i = 0; i < num_elements; i++) //"Выписываем" данные из временного массива в основной
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        static public void Sort(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2; //Делим последовательность на 2
                //Доходим "до корня" с каждой из сторон (можем считать 1 элемент - отсортированным)
                Sort(numbers, left, mid);
                Sort(numbers, (mid + 1), right);
                Merge(numbers, left, (mid + 1), right); //Объединяем последовательности, пока не получим одну
            }
        }

        public static void Main()
        {
            int[] arr = { 12, 11, -5, 0, 6, 34 }; //Исходная последовательность

            Console.WriteLine("Сортировка слиянием");
            Sort(arr, 0, arr.Length-1);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
}