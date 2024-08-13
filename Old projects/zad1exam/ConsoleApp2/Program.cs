using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfIndicates = int.Parse(Console.ReadLine());
            string pathern = @"|(?<name>[A-Z{4,}]+)|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";
            string input=Console.ReadLine();
            for (int i = 1; i < numOfIndicates; i++)
            {
                Match match = Regex.Match(input, pathern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string title = match.Groups["title"].Value;
                    int strenght = match.Groups["name"].Value.Length;
                    int armor = match.Groups["title"].Value.Length;

                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {strenght}");
                    Console.WriteLine($">> Armor: {armor}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }

                input = Console.ReadLine();
            }

        }
    }
}
