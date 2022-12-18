namespace ConsoleApp1
{
    internal class BinaryTrees
    {
        public BinaryTrees left, right, parent;
        public int value;
        public BinaryTrees(int value, BinaryTrees parent)
        {
            this.value = value;
            this.parent = parent;
        }
        public void Add(int value) //Добавление листьев
        {
            if (value > this.value)
            {
                if (this.right == null)
                {
                    this.right = new BinaryTrees(value, this);
                }
                else
                {
                    this.right.Add(value);
                }
            }
            else
            {
                if (this.left == null)
                {
                    this.left = new BinaryTrees(value, this);
                }
                else
                {
                    this.left.Add(value);
                }
            }
        }
        public BinaryTrees _Search(BinaryTrees item, int value) //Функция поиска
        {
            if (item == null) return null;            
            if (item.value == value) return item;
            if (item.value < value) return _Search(item.right, value);
            return _Search(item.left, value);
        }
        public BinaryTrees Search(int value) //Удобность использования функции поиска
        {
            return _Search(this, value);
        }
        public void Remove(int value) //Удаление корня, листьев и т.п.
        {
            BinaryTrees item = this.Search(value) ;
            if (item == null) return;
            BinaryTrees currentTree = null;
            //Удаление корня
            if (this == item)
            {
                if (item.right != null)
                {
                    currentTree = item.right;
                    while (currentTree.left != null)
                    {
                        currentTree = currentTree.left;
                    }

                }
                else if (item.left != null)
                {
                    currentTree = item.left;
                    while (currentTree.right != null)
                    {
                        currentTree = currentTree.right;
                    }
                }
                int val = currentTree.value;
                Remove(val);
                item.value = val;
                
            }
            //Удаление листьев
            if (item.left == null && item.right == null && item.parent != null)
            {
                if (item.parent.right == item)
                {
                    item.parent.right = null;
                }
                else
                {
                    item.parent.left = null;
                }
            }
            //Удаление узла, который имеет левого потомка
            if (item.left != null && item.right == null && item.parent != null)
            {
                item.left.parent = item.parent;
                if (item == item.parent.left)
                {
                    item.parent.left = item.left;
                }
                else if (item == item.parent.right)
                {
                    item.parent.right = item.left;
                }
                
            }
            //Удаление узла, который имеет правого потомка
            if (item.left == null && item.right != null && item.parent != null)
            {
                item.right.parent = item.parent;
                if (item == item.parent.left)
                {
                    item.parent.left = item.right;
                }
                else if (item == item.parent.right)
                {
                    item.parent.right = item.right;
                }

            }
            //Удаление узла, который имеет оба потомка
            if (item.left != null && item.right != null && item.parent != null)
            {
                currentTree = item.right;
                if (currentTree.left != null)
                {
                    while (currentTree.left != null)
                    {
                        currentTree = currentTree.left;
                    }
                    if (currentTree.right != null)
                    {
                        currentTree.right.parent = currentTree.parent;
                        currentTree.parent.left = currentTree.right;
                    }
                    else
                    {
                        currentTree.parent.left = null;
                    }
                    item.left.parent = currentTree;
                    currentTree.left = item.left;
                    if (item.parent.right == item)
                    {                        
                        currentTree.parent = item.parent.right;
                        item.parent.right = currentTree;
                    }
                    else
                    {
                        currentTree.parent = item.parent.left;
                        item.parent.left = currentTree;
                    }
                    currentTree.right = item.right;
                    item.right.parent = currentTree;
                }
                else
                {
                    item.left.parent = currentTree;
                    currentTree.left = item.left;
                    currentTree.parent = item.parent;
                    if (item.parent.left == item)
                    {
                        item.parent.left = currentTree;
                    }
                    else
                    {
                        item.parent.right = currentTree;
                    }
                }

            }

        }
        private void _print(BinaryTrees node) //Вывод значений (в линейно-скобочном виде)
        {
            Console.Write(node);
            if (node.left != null || node.right != null)
            {
                Console.Write("(");
                if (node.left != null)
                {
                    _print(node.left);
                }
                Console.Write(",");
                if (node.right != null)
                {
                    _print(node.right);
                }
                Console.Write(")");
            }
        }
        public void print() //Функция вывода
        {
            _print(this);
        }

        public override string ToString()
        {
            return value.ToString();
        }
        public void Menu() //Меню взаимодействия с дереом
        {
            bool exitCheck = false;
            int valueOfElements;
            Console.WriteLine("Меню:");
            do
            {
                Console.WriteLine("Чтобы добавить элемент нажмите 1");
                Console.WriteLine("Чтобы удалить элемент нажмите 2");
                Console.WriteLine("Чтобы вывести элементы дерева нажмите 3");
                Console.WriteLine("Чтобы выйти нажмите что угодно");
                int.TryParse(Console.ReadLine(), out int val);

                bool check = true;

                switch (val)
                {
                    case 1:
                        Console.WriteLine("Какое значение вы хотите добавить?");
                        check = int.TryParse(Console.ReadLine(), out valueOfElements);
                        if (check == false)
                        {
                            Console.WriteLine("Неверно, попробуйте ещё");
                            break;
                        }
                        else
                        {
                            Add(valueOfElements);
                            Console.WriteLine("Успешно");
                            break;
                        }
                    case 2:
                        Console.WriteLine("Какое значение вы хотите удалить?");
                        check = int.TryParse(Console.ReadLine(), out valueOfElements);
                        if (check == false)
                        {
                            Console.WriteLine("Неверно, попробуйте ещё");
                            break;
                        }
                        else
                        {
                            Remove(valueOfElements);
                            Console.WriteLine("Успешно");
                            break;
                        }
                    case 3:
                        print();
                        Console.WriteLine();
                        break;
                    default:
                        exitCheck = true;
                        break;
                }


            } while (exitCheck == false);
               

        }
    }
   
}
