using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Problem_6___Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> wordPairs = new Dictionary<string, string>();

            string cryptedText = Console.ReadLine();

            Regex regex = new Regex(@"(([\#?\@?]){1}(?<word>[A-Za-z]{3,})(\2){2}(?<mirrorWord>[A-Za-z]{3,})(\2))");
            MatchCollection wordMatches = regex.Matches(cryptedText);

            int matchCounter = 0;
            int wordPairsCounter = 0;

            foreach (Match wordMatch in wordMatches)
            {
                string word = wordMatch.Groups["word"].Value;
                string expectedMirrorWord = wordMatch.Groups["mirrorWord"].Value;



                if (expectedMirrorWord == string.Join("", word.Reverse().ToArray()))
                {
                    wordPairs[word] = expectedMirrorWord;
                    wordPairsCounter++;
                }

                matchCounter++;
            }

            if (matchCounter == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{matchCounter} word pairs found!");
                if (wordPairsCounter > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    int anotherCheatyCounter = 0;
                    foreach (KeyValuePair<string, string> Pair in wordPairs)
                    {
                        anotherCheatyCounter++;
                        if (anotherCheatyCounter == wordPairs.Count)
                        {
                            Console.Write($"{Pair.Key} <=> {Pair.Value}");
                            return;
                        }
                        Console.Write($"{Pair.Key} <=> {Pair.Value}, ");

                    }
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
        }
    }
}