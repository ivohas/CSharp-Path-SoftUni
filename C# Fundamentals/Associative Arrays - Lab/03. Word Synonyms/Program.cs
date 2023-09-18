using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pairCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> synonymList = new Dictionary<string, List<string>>();

            for (int i = 0; i < pairCount; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (synonymList.ContainsKey(word))
                {
                    synonymList[word].Add(synonym);
                }
                else
                {
                    List<string> newSymList = new List<string>() { synonym };
                    synonymList.Add(word, newSymList);
                }
            }

            foreach (var item in synonymList)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
