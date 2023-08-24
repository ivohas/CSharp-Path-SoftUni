using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] orderArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string productName = orderArgs[0];
                double price = double.Parse(orderArgs[1]);
                int quantity = int.Parse(orderArgs[2]);

                if (!products.ContainsKey(productName))
                {
                    products.Add(productName, new List<double>() { price, quantity });
                }
                else
                {
                    products[productName][0] = price;
                    products[productName][1] += quantity;
                }
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            }
        }
    }
}
