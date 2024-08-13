using System;
using System.Text.RegularExpressions;

namespace _02.BossRush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfIndicates = int.Parse(Console.ReadLine());
            Regex pathern = new Regex(@"|(?<names>[A-Z{4,}]+)|:#(?<titles>[A-Za-z]+ [A-Za-z]+)#");
            string indicate = null;
            for (int i = 0; i < numOfIndicates; i++)
            {
                indicate = Console.ReadLine();
                Match match = pathern.Match(indicate);
                if (match.Success)
                {
                    string names = match.Groups["names"].Value;
                    string titl = match.Groups["titles"].Value;
                    int power = match.Groups["name"].Value.Length;
                    int armor = match.Groups["title"].Value.Length;

                    Console.WriteLine($"{names}, The {titl}");
                    Console.WriteLine($">> Strength: {power}");
                    Console.WriteLine($">> Armor: {armor}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}