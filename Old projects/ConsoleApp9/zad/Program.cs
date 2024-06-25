using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            char[] chars = first.ToCharArray();
            List<char> charsOfFirst= chars .ToList();
            char[] charsd = second.ToCharArray();
            List<char>charsOfSecond= charsd .ToList();
            for (int i = 0; i <charsOfFirst.Count; i++)
            {
                while (charsOfSecond.Contains(charsOfFirst[i]))
                {
                    charsOfSecond.Remove(charsOfFirst[i]);
                }
            }
            Console.WriteLine(String.Join("",charsOfSecond));
        }
    }
}
