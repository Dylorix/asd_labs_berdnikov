namespace ConsoleApp1
{
    internal class Program
    {
        static bool check(string str) //Проверка правильности скобочной последовательности
        {
            var stack = new Stack<char>(); //Создаём стек  
            for (int i = 0; i < str.Length; ++i) //Смотрим всю строку посимвольно
            {
                if (str[i] == '{' || str[i] == '(' || str[i] == '[') //Если видим скобку, пушим её в стек
                {
                    stack.Push(str[i]);
                }
                else //Иначе
                {
                    switch (str[i])
                    {
                        case '}': //Если видим закрывающую скобку
                            if (stack.Count != 0)
                            {
                                if (stack.Peek() == '{') //И если верх стека такая же скобка
                                {
                                    stack.Pop(); //То достаём её из сткека
                                }
                            }
                            else //Если нет, то скобочная последовательноть не верна
                            {
                                return false;
                            }
                            break;

                        case ')': //Аналогично с круглой скобкой
                            if (stack.Count != 0)
                            {
                                if (stack.Peek() == '(')
                                {
                                    stack.Pop();
                                }
                            }
                            else
                            {
                                return false;
                            }
                            break;

                        case ']': //Аналогично с квадратной скобкой
                            if (stack.Count != 0)
                            {
                                if (stack.Peek() == '[')
                                {
                                    stack.Pop();
                                }
                            }
                            else
                            {
                                return false;
                            }
                            break;

                        default:
                            break;
                    }
                }

            }
            return stack.Count == 0? true : false; //Если стек пустой, значит скобочная последовательность верна
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка правильности скобочной последовательности");
            string str = ""; //Проверяемая строка
            Console.WriteLine("Введите строку");
            str = Console.ReadLine();

            if (check(str) == true)
            {
                Console.WriteLine("Строка существует");
            }
            else
            {
                Console.WriteLine("Строка не существует");
            }

            //Пример существующей (1+3[8*2]/5(({})))
            //Пример не существующей (1+3[8*2]/5(({})))}
        }
    }
}