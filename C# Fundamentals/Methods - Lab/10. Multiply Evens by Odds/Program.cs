using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var sumOfEvenDigits = GetSumOfEvenDigits(number);
            var sumOfOddDigits = GetSumOfOddDigits(number);
            Console.WriteLine(sumOfEvenDigits*sumOfOddDigits);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;

                if (digit % 2 == 0)
                {
                    sum += number % 10;
                }
                number /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;

                if (digit % 2 != 0)
                {
                    sum += number % 10;
                }
                number /= 10;
            }

            return sum;
        }
    }
}
