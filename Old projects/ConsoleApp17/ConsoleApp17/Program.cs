using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                List<string> info = Console.ReadLine().Split().ToList();
                string continent = info[0];
                string country = info[1];
                string city = info[2];
                AddInfo(cities, continent, country, city);


            }
            foreach (var continent in cities.Keys)
            {
                Console.WriteLine($"{continent}:");
                foreach (var item in cities[continent].Keys)
                {
                    List<string> tokens = cities[continent][item];
                    Console.Write($"  {item} -> ");
                    Console.WriteLine(string.Join(", ", tokens));
                }
            }
        }

        private static void AddInfo(Dictionary<string, Dictionary<string,
            List<string>>> cities, string continent, string country, string city)
        {//add continents
            if (!cities.ContainsKey(continent))
                cities.Add(continent, new Dictionary<string, List<string>>());
            Dictionary<string, List<string>> contries = cities[continent];
            // add country
            if (!contries.ContainsKey(country))
                contries.Add(country, new List<string>());
            contries[country].Add(city);


        }
    }
}
