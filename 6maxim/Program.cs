using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6maxim
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
                string stro = Zapis(stroka);
                Console.WriteLine("Выберите вариант сортировки: 1 - быстрая сортировка, 2 - сортировка деревом");
                string n = Console.ReadLine();
                if (n == "1")
                {

                    string itog = Quicksort(stroka);
                    Console.WriteLine("Отсортированная обработанная строчка:" + itog);
                    
                }
                if (n == "2")
                {
                    string itog = Treesort(stroka);
                    Console.WriteLine("Отсортированная обработанная строчка:" + itog);
                    
                }
                int random = GetRandomNum(0, stro.Length);
                stro = stro.Remove(random, 1);
                Console.WriteLine("«Урезанная» обработанная строка: " + stro);
                Console.ReadLine();
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
        
        private static int GetRandomNum(int min, int max)
        {
            int randomNum;
            try
            {
                // Формируем URL для получения случайного числа через удалённый API
                string url = $"https://www.random.org/integers/?num=1&min={min}&max={max - 1}&col=1&base=10&format=plain&rnd=new";
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result; // Отправляем GET-запрос на указанный URL и получаем ответ
                    randomNum = int.Parse(response.Content.ReadAsStringAsync().Result); // Преобразуем ответ в строку и парсим число из строки 
                    Console.WriteLine($"\nСлучайное число {randomNum}, успешно получено через API.");// Выводим сообщение об успешном получении случайного числа через API                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nНе удалось получить случайное число через удалённый API, число будет получено средствами .NET.");
                Random rnd = new Random(); 
                randomNum = rnd.Next(min, max);
                Console.WriteLine($"Случайное число {randomNum}");            
            }
            return randomNum;
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

        static string Zapis(string stroka)
        {
            if (stroka.Length % 2 == 0)
            {
                int index = stroka.Length / 2;
                string newst = Reverse(stroka.Substring(0, index));
                string newst2 = Reverse(stroka.Substring(index));
                string sum = newst + newst2;
                Console.WriteLine("Отсортированная строка: " + sum);

                string we = Find(sum);
                Console.WriteLine("Наибольшая подстрока, начинающаяся и заканчивающаяся на гласную букву: " + we);
                return sum;
            }
            else
            {
                string revst = Reverse(stroka);
                string sum2 = revst + stroka;
                Console.WriteLine("Отсортированная строка: " + sum2);
                string we2 = Find(sum2);
                Console.WriteLine("Наибольшая подстрока, начинающаяся и заканчивающаяся на гласную букву: " + we2);
                return sum2;
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
