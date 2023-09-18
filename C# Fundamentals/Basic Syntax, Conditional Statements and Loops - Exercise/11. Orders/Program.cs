using System;

namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double pricePerCapsule = 0;
            int days = 0;
            int capsulesCount = 0;
            double totalSum = 0;

            for (int i = 0; i < n; i++)
            {
                pricePerCapsule = double.Parse(Console.ReadLine());
                days = int.Parse((Console.ReadLine()));
                capsulesCount = int.Parse((Console.ReadLine()));

                double sum = pricePerCapsule * days * capsulesCount;
                Console.WriteLine($"The price for the coffee is: ${sum:f2}");
                totalSum += sum;
            }

            Console.WriteLine($"Total: ${totalSum:f2}");
        }
    }
}
