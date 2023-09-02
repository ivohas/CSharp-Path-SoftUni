using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int L = int.Parse(Console.ReadLine());

                sum += L;

                if (sum > 255)
                {
                    sum -= L;
                    Console.WriteLine("Insufficient capacity!");
                }

            }
            Console.WriteLine(sum);
        }
    }
}
