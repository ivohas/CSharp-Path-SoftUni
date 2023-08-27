using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleQ = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double pricePerHuman = 0;
            double totalPrice = 0;

            if (groupType == "Students")
            {
                if (day == "Friday")
                {
                    pricePerHuman = 8.45;
                }
                else if (day == "Saturday")
                {
                    pricePerHuman = 9.80;
                }
                else if (day == "Sunday")
                {
                    pricePerHuman = 10.46;
                }

                if (peopleQ >= 30)
                {
                    totalPrice = peopleQ * pricePerHuman - 0.15 * (peopleQ * pricePerHuman);
                }
                else
                {
                    totalPrice = peopleQ * pricePerHuman;
                }
            }
            else if (groupType == "Business")
            {
                if (day == "Friday")
                {
                    pricePerHuman = 10.90;
                }
                else if (day == "Saturday")
                {
                    pricePerHuman = 15.60;
                }
                else if (day == "Sunday")
                {
                    pricePerHuman = 16;
                }

                if (peopleQ >= 100)
                {
                    totalPrice = (peopleQ - 10) * pricePerHuman;
                }
                else
                {
                    totalPrice = peopleQ * pricePerHuman;
                }
            }
            else if (groupType == "Regular")
            {
                if (day == "Friday")
                {
                    pricePerHuman = 15;
                }
                else if (day == "Saturday")
                {
                    pricePerHuman = 20;
                }
                else if (day == "Sunday")
                {
                    pricePerHuman = 22.50;
                }

                if (peopleQ > 9 && peopleQ < 21)
                {
                    totalPrice = peopleQ * pricePerHuman - (0.05 * (peopleQ * pricePerHuman));
                }
                else
                {
                    totalPrice = peopleQ * pricePerHuman;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
