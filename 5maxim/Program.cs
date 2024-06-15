using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5maxim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string stroka = Console.ReadLine();
            if (Regex.IsMatch(stroka, @"^[a-z]+$"))
            {
                Count(stroka);
                Zapis(stroka);
                Console.WriteLine("Выберите вариант сортировки: 1 - быстрая сортировка, 2 - сортировка деревом");
                string n = Console.ReadLine();
                if (n == "1" )
                {
                    
                    string itog = Quicksort(stroka);
                    Console.WriteLine("Отсортированная строчка:" + itog);
                    Console.Read();
                }
                if (n== "2")
                {
                    string itog = Treesort(stroka);
                    Console.WriteLine("Отсортированная строчка:" + itog);
                    Console.Read();
                }
            }
            else
            {
                Console.WriteLine("Были введены неподходящие символы!");
                foreach (char c in stroka)
                {
                    if (!char.IsLower(c) || c < 'a' || c > 'z')
                    {
                        Console.WriteLine($"Недопустимый символ: {c}");
                    }
                }
                Console.Read();
            }
        }
        public static string Quicksort(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray); 
            
        }
        public static string Treesort(string str)
        {
            // Создаем новое дерево
            TreeNode root = null;

            // Добавляем каждый символ строки в дерево
            foreach (char c in str)
            {
                root = Insert(root, c);
            }

            // Обходим дерево в порядке возрастания и собираем отсортированную строку
            StringBuilder sortedString = new StringBuilder();
            InOrderTraversal(root, sortedString);

            return sortedString.ToString();
        }
        private class TreeNode
        {
            public char Value;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(char value)
            {
                Value = value;
                left = null;
                right = null;
            }
        }
        static void InOrderTraversal(TreeNode node, StringBuilder result)
        {
            if (node != null)
            {
                InOrderTraversal(node.left, result);
                result.Append(node.Value);
                InOrderTraversal(node.right, result);
            }
        }
        static TreeNode Insert(TreeNode node, char value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (value < node.Value)
            {
                node.left = Insert(node.left, value);
            }
            else if (value > node.Value)
            {
                node.right = Insert(node.right, value);
            }

            return node;
        }

        static string Find(string str)
        {
            string lSub = "";
            string vowels = "aeiouy";
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(str[i]))
                {
                    for (int j = str.Length - 1; j > i; j--)
                    {
                        if (vowels.Contains(str[j]))
                        {
                            string substring = str.Substring(i, j - i + 1);
                            if (substring.Length > lSub.Length)
                            {
                                lSub = substring;
                            }
                            break;
                        }
                    }
                }
            }
            return lSub;
        }
        static void Count(string st)
        {
            string result = new string(st.Distinct().ToArray());
            for (int i = 0; i < result.Length; i++)
            {
                int schet = 0;
                for (int j = 0; j < st.Length; j++)
                {
                    if (result[i] == st[j])
                    {
                        schet++;
                    }
                }
                Console.WriteLine("Буква: " + result[i] + " кол-во: " + schet);
            }
        }

        static void Zapis(string stroka)
        {
            if (stroka.Length % 2 == 0)
            {
                int index = stroka.Length / 2;
                string newst = Reverse(stroka.Substring(0, index));
                string newst2 = Reverse(stroka.Substring(index));
                string sum = newst + newst2;
                Console.WriteLine(sum);

                string we = Find(sum);
                Console.WriteLine("Наибольшая подстрока, начинающаяся и заканчивающаяся на гласную букву: " + we);
                
            }
            else
            {
                string revst = Reverse(stroka);
                string sum2 = revst + stroka;
                Console.WriteLine(sum2);
                string we2 = Find(sum2);
                Console.WriteLine("Наибольшая подстрока, начинающаяся и заканчивающаяся на гласную букву: " + we2);
                
            }
        }
        static string Reverse(string podstroka)
        {
            char[] charArray = podstroka.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
