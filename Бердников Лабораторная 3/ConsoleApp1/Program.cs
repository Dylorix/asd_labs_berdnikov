using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> v = new List<int>(); //Вектор, куда будем ставить полученные числа
    internal static void Main()
    {
        int x = 1000; // Произвольное число для которого хотим получить результат
        int a = 1;
        int b = 0;
        int c = 0;
        int i = 0;
        
        while (a <= x) // Последовательно составляем все числа состоящие из степеней 3, 5 и 7, затем записываем их в вектор
        {
            b = a;
            while (b <= x)
            {
                c = b;
                while (c <= x)
                {
                    v.Add(c);
                    i++;
                    c *= 7;
                }
                b *= 5;
            }
            a *= 3;
        }

        v.Sort((a, b) => -1 * a.CompareTo(b)); //Сортируем полученный вектор для более удобного восриятия информации

        for (int k = 0; k < i; k++) // Выводим полученные значения.
        {
            Console.WriteLine(v[k]);
        }
    }
}