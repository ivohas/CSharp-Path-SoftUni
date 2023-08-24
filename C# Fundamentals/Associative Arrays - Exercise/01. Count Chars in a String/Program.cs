using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> characters = new Dictionary<char, int>();

            string[] text = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            char[] chars = string.Join(string.Empty, text).ToCharArray();

            foreach (var word in chars)
            {
                if (!characters.ContainsKey(word))
                {
                    characters[word] = 0;
                }

                characters[word] += 1;
            }

            foreach (var kvp in characters)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

        }
    }
}
