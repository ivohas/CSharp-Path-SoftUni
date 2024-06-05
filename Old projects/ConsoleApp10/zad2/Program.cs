using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Threading.Tasks;

namespace zad2
{     
    internal class Program
    {
        


        static void Main(string[] args)
        {  
            int totalPoints = 0;
            List<string>Places=new List<string>();
            string places = Console.ReadLine();
            // string pattern = @"(=|/)(?<destination>[A-Z]+[A-Za-z]{2,})(\1)";
            Regex regex = new Regex(@"(=|/)(?<destination>[A-Z]+[A-Za-z]{2,})(\1)");
            MatchCollection matches = regex.Matches(places);
            foreach (var currMatch in matches)
            {
                string currentDestination = currMatch.[2].Value;
                Places.Add(currentDestination);
                totalPoints+=currentDestination .Length;
            }
            Console.WriteLine("Destinations:" + String.Join(", ",Places));
            Console.WriteLine($"Travel Points: { totalPoints}");
            
        }
    }
}
