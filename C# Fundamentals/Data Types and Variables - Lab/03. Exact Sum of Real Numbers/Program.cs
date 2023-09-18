using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal sum = 0;

            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;

            }

            Console.WriteLine(sum);
        }
    }
}
