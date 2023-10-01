using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> text = Console.ReadLine().ToList();

            for (int i = 0; i < text.Count - 1; i++)
            {
                char currentChar = text[i];
                char nextChar = text[i + 1];
                if (currentChar == nextChar)
                {
                    text.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(String.Join("", text));
        }
    }
}
