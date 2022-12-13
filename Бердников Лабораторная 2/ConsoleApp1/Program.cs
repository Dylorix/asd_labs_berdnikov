namespace ConsoleApp1
{
    class Calc
    {
        static bool Check(string str) //Проверка правильности скобочной последовательности (Лаба 1)
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
            return stack.Count == 0 ? true : false; //Если стек пустой, значит скобочная последовательность верна
        }
        static private bool IsDelimeter(char c) //Перед нами равно?
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char с) //Пред нами оператор?
        {
            if (("+-/*()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s) //Расставляем приоритет знаков (операторов)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                default: return 5;
            }
        }
        static public double? Calculate(string input)
        {
            bool check = Check(input); //Правильно ли стоят скобки?
            if (check == false) 
                return null;
            
            // Преобразуем в обратную польскую нотацию
            string output = GetExpression(input);
            double? result = Counting(output);
            return result; //Возвращаем результат
        }
        static private string GetExpression(string input) //Обработка выражения
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>(); //Создаём стек 

            for (int i = 0; i < input.Length; i++)
            {
                
                if (IsDelimeter(input[i]))
                    continue;

                //Если цифра
                if (Char.IsDigit(input[i])) 
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Читаем до разделителя или оператора, что бы получить число
                    {
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        i++;
                        if (i == input.Length) break; //Если символ - последний, выходим.
                    }

                    output += " "; 
                    i--; 
                }
                if (IsOperator(input[i])) //Если оператор
                {
                    if (input[i] == '(') //Если символ - открывающая скобка
                        operStack.Push(input[i]); //Пушим её в стек
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else 
                    {
                        if (operStack.Count > 0)
                        
                            //Если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";
                        
                        operStack.Push(char.Parse(input[i].ToString())); 

                    }
                }
            }

            while (operStack.Count > 0) //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
                output += operStack.Pop() + " ";

            return output; //Возвращаем выражение в постфиксной записи
        }
        static private double? Counting(string input) //Подсчёт
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                if (Char.IsDigit(input[i])) //Если символ - цифра, то читаем все число и записываем на вершину стека
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Не закончилось ли число
                    {
                        a += input[i]; 
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a)); //Пушим в стек
                    i--;
                }

                else if (IsOperator(input[i]))  //Если символ - оператор
                {
                    double a = temp.Pop(); //Берем два последних значения из стека
                    double b = temp.Pop();

                    switch (input[i]) //Производим над ними действие, согласно оператору
                    {
                        case '+':
                            result = b + a;
                            break;
                        case '-': 
                            result = b - a;
                            break;
                        case '*': 
                            result = b * a;
                            break;
                        case '/':
                            if (a == 0) return null;
                            result = b / a;
                            break;
                    }
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача об арифметическом выражении");
            Console.WriteLine("Введите выражние: "); //Пример 2+7*(3/9)-5=
            double? result = Calc.Calculate(Console.ReadLine());
            
            if (result == null) 
                Console.WriteLine("Неверное выражение");
            else 
                Console.WriteLine(result);
        }
    }
}