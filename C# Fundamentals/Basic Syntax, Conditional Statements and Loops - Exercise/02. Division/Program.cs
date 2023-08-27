using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int divisibleNum = 0;

            if (number % 10 == 0)
            {
                divisibleNum = 10;
                Console.WriteLine($"The number is divisible by {divisibleNum}");
            }
            else if (number % 7 == 0)
            {
                divisibleNum = 7;
                Console.WriteLine($"The number is divisible by {divisibleNum}");
            }
            else if (number % 6 == 0)
            {
                divisibleNum = 6;
                Console.WriteLine($"The number is divisible by {divisibleNum}");
            }
            else if (number % 3 == 0)
            {
                divisibleNum = 3;
                Console.WriteLine($"The number is divisible by {divisibleNum}");
            }
            else if (number % 2 == 0)
            {
                divisibleNum = 2;
                Console.WriteLine($"The number is divisible by {divisibleNum}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }

        }
    }
}
