using System;

namespace Vending
{
    class Program
    {
        static void Main(string[] args)
        {
            string coin = Console.ReadLine();
            decimal sumCoins = 0;

            while (coin != "Start")
            {
                switch (coin)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        sumCoins = sumCoins + decimal.Parse(coin);
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coin}");
                        break;
                }
                coin = Console.ReadLine();
            }

            string product = Console.ReadLine();
            decimal productPrice = 0;

            while (product != "End")
            {
                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.0m;
                        break;
                    case "Water":
                        productPrice = 0.7m;
                        break;
                    case "Crisps":
                        productPrice = 1.5m;
                        break;
                    case "Soda":
                        productPrice = 0.8m;
                        break;
                    case "Coke":
                        productPrice = 1.0m;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                if (sumCoins >= productPrice && sumCoins > 0 && productPrice > 0)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumCoins = sumCoins - productPrice;
                    productPrice = 0;
                }
                else if (productPrice > 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    productPrice = 0;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sumCoins:F2}");
        }
    }

}