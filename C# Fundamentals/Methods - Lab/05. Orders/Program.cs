using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            ProductPricing(product, quantity);
        }

        static void ProductPricing(string product, int quantity)
        {
            double price = 0;
            if (product == "coffee")
            {
                price = 1.50 * quantity;
            }
            else if (product == "water")
            {
                price = 1.00 * quantity;
            }
            else if (product == "coke")
            {
                price = 1.40 * quantity;
            }
            else if (product == "snacks")
            {
                price = 2.00 * quantity;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
