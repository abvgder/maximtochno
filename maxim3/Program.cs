using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace maxim3
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
                Console.WriteLine(newst + newst2);
                Console.Read();
            }
            else
            {
                string revst = Reverse(stroka);
                Console.WriteLine(revst + stroka);
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
