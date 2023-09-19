using System;

namespace Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            decimal priceWithoutTax = 0;
            decimal taxes = 0;
            decimal totalPrice = 0;

            while (command != "regular" && command != "special")
            {
                decimal price = decimal.Parse(command);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;
                }

                command = Console.ReadLine();

                priceWithoutTax += price;
                taxes = .2m * priceWithoutTax;
            }
            totalPrice = priceWithoutTax + taxes;

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            if (command == "special")
            {
                totalPrice -= totalPrice * .1m;
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTax:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");

            }
            else if (command == "regular")
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTax:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
        }
    }
}
