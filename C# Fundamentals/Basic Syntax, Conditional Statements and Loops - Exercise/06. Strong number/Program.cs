using System;

namespace _06._Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            //145! = 1! +4! + 5!
            long factorielSum = 0;

            for (int i = 0; i <= number.Length - 1; i++)
            {
                char currentCharacter = number[i];
                int currentDigit = (int)currentCharacter - 48;

                long currentDigitFactoriel = 1;
                for (int r = currentDigit; r > 1; r--)
                {
                    currentDigitFactoriel *= r;
                }

                factorielSum += currentDigitFactoriel;
            }

            if (factorielSum == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
