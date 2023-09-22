using System;
using System.Linq;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleSymbol(input);
        }

        static void MiddleSymbol(string word)
        {
            if (word.Length % 2 == 1)
            {
                Console.WriteLine($"{word[word.Length / 2]}");
            }
            else
            {
                Console.WriteLine($"{word[word.Length / 2 - 1]}{word[word.Length / 2]}");
            }
        }
    }
}
