using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string stroka = Console.ReadLine();
            Zapis(stroka);
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
