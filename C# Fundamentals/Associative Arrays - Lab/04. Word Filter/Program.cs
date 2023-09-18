using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            string[] filteredWords = words.Where(x => x.Length % 2 == 0).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, filteredWords));
        }
    }
}
