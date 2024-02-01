using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            foreach (double num in nums)
            {
                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }
                numbers[num]++;
            }

            foreach (var kvp in numbers)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
