using System;

namespace _01._Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());

            meters /= 1000;

            Console.WriteLine($"{meters:f2}");
        }


    }
}
