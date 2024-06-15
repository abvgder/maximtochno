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
                    Quicksort(stroka);
                }
                if (n== "2")
                {

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
        static void Quicksort(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            Console.WriteLine("Отсортированная строчка:" + charArray);
            Console.Read();
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
                Console.Read();
            }
            else
            {
                string revst = Reverse(stroka);
                string sum2 = revst + stroka;
                Console.WriteLine(sum2);
                string we2 = Find(sum2);
                Console.WriteLine("Наибольшая подстрока, начинающаяся и заканчивающаяся на гласную букву: " + we2);
                Console.Read();
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
