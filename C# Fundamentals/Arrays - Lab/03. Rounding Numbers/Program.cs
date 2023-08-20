using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] listOfNums = Console.ReadLine()
                                        .Split()
                                        .Select(double.Parse)
                                        .ToArray();

            for (int i = 0; i < listOfNums.Length; i++)
            {
                Console.WriteLine($"{listOfNums[i]} => {Math.Round(listOfNums[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
