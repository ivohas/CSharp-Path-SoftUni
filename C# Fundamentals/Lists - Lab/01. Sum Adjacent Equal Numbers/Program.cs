using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            int index = 1;
            while (index < numbers.Count)
            {
                if (numbers[index] == numbers[index - 1])
                {
                    numbers[index - 1] += numbers[index];
                    numbers.RemoveAt(index);
                    index = 1;
                }
                else
                {
                    index++;
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
