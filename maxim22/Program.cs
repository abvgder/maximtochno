﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace maxim22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string stroka = Console.ReadLine();
            if (Regex.IsMatch(stroka, @"^[a-z]+$"))
            {
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
