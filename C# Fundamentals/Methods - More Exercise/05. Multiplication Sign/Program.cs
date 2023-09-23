using System;

namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            PrintPositiveOrNegative(firstNumber, secondNumber, thirdNumber);
        }

        static void PrintPositiveOrNegative(int firstNumber, int secondNumber, int ThirdNumber)
        {
            int minusCounter = 0;

            if (firstNumber == 0 || secondNumber == 0 || ThirdNumber == 0)
            {
                Console.WriteLine("zero");
                return;
            }

            if (firstNumber / 1 == -(Math.Abs(firstNumber)))
            {
                minusCounter++;
            }
            if (secondNumber / 1 == -(Math.Abs(secondNumber)))
            {
                minusCounter++;
            }
            if (ThirdNumber / 1 == -(Math.Abs(ThirdNumber)))
            {
                minusCounter++;
            }

            if (minusCounter % 2 != 0)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
