using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main()
        {
            int toNumber = int.Parse(Console.ReadLine());

            PrintNumbersFromTo(toNumber);
        }

        private static void PrintNumbersFromTo(int toNumber)
        {
            for (int i = 1; i <= toNumber; i++)
            {
                if (IsSumOfDigitsDivisibleBy8(i) && AtleastOneDigitIsOdd(i))
                {
                    Console.WriteLine(i);

                }
            }
        }
        static bool IsSumOfDigitsDivisibleBy8(int number)
        {
            int digitSum = 0;
            while (number > 0)
            {
                digitSum += number % 10;
                number /= 10;
            }
            if (digitSum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool AtleastOneDigitIsOdd(int toNumber)
        {
            while (toNumber > 0)
            {
                if (toNumber % 10 % 2 == 1)
                {
                    return true;
                }
                    toNumber /= 10;
            }

            return false;
        }
    }
}
