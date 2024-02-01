using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var letters = new Dictionary<char, int>();
            string text = Console.ReadLine();

            foreach (char ch in text)
            {
                if (!letters.ContainsKey(ch))
                {
                    letters[ch] = 0;
                }
                letters[ch]++;
            }

            foreach (var letter in letters.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
