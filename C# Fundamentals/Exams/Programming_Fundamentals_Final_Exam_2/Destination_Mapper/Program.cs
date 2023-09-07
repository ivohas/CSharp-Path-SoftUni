using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_4___Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> destionations = new List<string>();
            int travelPoints = 0;

            string input = Console.ReadLine();
            Regex dests = new Regex(@"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})(\1)");
            MatchCollection matches = dests.Matches(input);

            foreach (Match currMatch in matches)
            {
                string currDestination = currMatch.Groups["destination"].Value;
                destionations.Add(currDestination);
                travelPoints += currDestination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destionations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
