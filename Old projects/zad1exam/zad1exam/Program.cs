using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zad1exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
          string pattern = @"\|(?<names>[A-Z]{4,})\|:#(?<first>[A-Z])*\s(?<second>[a-z])+#";
            string input = null;
            for (int i = 0; i < inputNum; i++)
            {
                input = Console.ReadLine();

                MatchCollection maches = Regex.Matches(input, pattern);
                foreach (Match m in maches)
                {
                    string curBoss = m.Groups["boss"].Value;
                    int power = curBoss.Length;
                    string first = m.Groups["first"].Value;
                    string second = m.Groups["second"].Value;
                    int armor = first.Length + 1 + second.Length;
                    Console.WriteLine($"{curBoss}, The {first} {second}");
                    Console.WriteLine($">> Strength: {power}");
                    Console.WriteLine($">> Armor: { armor}");

                }
            }
        }
    }
}
