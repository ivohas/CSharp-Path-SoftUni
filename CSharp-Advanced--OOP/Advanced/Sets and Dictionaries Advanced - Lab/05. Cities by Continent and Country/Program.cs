using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            int citiesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < citiesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                AddCity(cities, continent, country, city);
            }

            Print(cities);
        }

        private static void AddCity(Dictionary<string, Dictionary<string, List<string>>> cities, string continent, string country, string city)
        {
            if (!cities.ContainsKey(continent))
                cities.Add(continent, new Dictionary<string, List<string>>());
            Dictionary<string, List<string>> countries = cities[continent];
            if (!countries.ContainsKey(country))
                countries.Add(country, new List<string>());
            countries[country].Add( city);
        }

        private static void Print(Dictionary<string, Dictionary<string, List<string>>> cities)
        {
            foreach (var continent in cities.Keys)
            {
                Console.WriteLine(continent + ":");
                foreach (var country in cities[continent].Keys)
                {
                    Console.Write("  " + country + " -> ");
                    var allcities = cities[continent][country];
                    Console.WriteLine(string.Join(", ", allcities));
                }
            }
        }
    }
}
