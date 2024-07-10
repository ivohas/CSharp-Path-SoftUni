using System;
namespace ComputerRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            double pricePerHour = 0.0;

            if (month == "march" || month == "april" || month == "may")
            {
                if (timeOfDay == "day")
                {
                    pricePerHour = 10.50;
                }
                else
                {
                    pricePerHour = 8.40;
                }
            }
            else if (month == "june" || month == "july" || month == "august")
            {
                if (timeOfDay == "day")
                {
                    pricePerHour = 12.60;
                }
                else
                {
                    pricePerHour = 10.20;
                }
            }

            if (peopleCount >= 4)
            {
                pricePerHour -= pricePerHour * 0.10;
            }

            if (hours >= 5)
            {
                pricePerHour -= pricePerHour * 0.50;
            }
            double totalCost = pricePerHour * hours * peopleCount;

            Console.WriteLine($"Price per person for one hour: {pricePerHour:F2}");
            Console.WriteLine($"Total cost of the visit: {totalCost:F2}");
        }
    }
}
