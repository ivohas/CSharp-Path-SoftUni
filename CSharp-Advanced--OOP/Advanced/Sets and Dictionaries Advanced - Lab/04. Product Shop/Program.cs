using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] cmdArgs = command.Split(", ");
                string shopName = cmdArgs[0];
                string currProduct = cmdArgs[1];
                double currProductValue = double.Parse(cmdArgs[2]);

                AddPorduct(shops, shopName, currProduct, currProductValue);

                command = Console.ReadLine();
            }

            PrintPrices(shops);
        }

        static void AddPorduct(Dictionary<string, Dictionary<string, double>> shops, string shop, string product, double price)
        {
            if (!shops.ContainsKey(shop))
                shops.Add(shop, new Dictionary<string, double>());
            shops[shop][product] = price;
        }

        static void PrintPrices(Dictionary<string, Dictionary<string, double>> shops)
        {
            foreach (var kvp in shops.OrderBy(s => s.Key))
            {
                string shop = kvp.Key;
                Console.WriteLine(shop + "->");
                var products = kvp.Value;
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }

            }
        }
    }
}
