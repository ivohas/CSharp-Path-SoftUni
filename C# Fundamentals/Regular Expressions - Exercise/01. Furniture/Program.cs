using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> furnitureBought = new List<string>();
            decimal totalMoneySpend = 0;

            string pattern = @"[>]{2}(?<name>[A-Za-z]+)[<]{2}(?<price>\d+(\.\d+)?)\!(?<quantity>\d+)";

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match furnitureInfo = Regex.Match(input, pattern);

                if (furnitureInfo.Success)
                {
                    string furnitureName =
                        furnitureInfo.Groups["name"].Value;
                    decimal price =
                        decimal.Parse(furnitureInfo.Groups["price"].Value);
                    int quantity =
                        int.Parse(furnitureInfo.Groups["quantity"].Value);

                    furnitureBought.Add(furnitureName);
                    totalMoneySpend += price * quantity;
                }
            }

            PrintOutput(furnitureBought, totalMoneySpend);
        }

        static void PrintOutput(List<string> furnitures, decimal moneySpend)
        {
            Console.WriteLine("Bought furniture:");

            foreach (var furnitureName in furnitures)
            {
                Console.WriteLine(furnitureName);
            }

            Console.WriteLine($"Total money spend: {moneySpend:f2}");
        }
    }
}
