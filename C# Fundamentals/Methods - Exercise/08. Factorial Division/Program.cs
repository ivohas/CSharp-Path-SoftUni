using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            PrintFactorial(firstNumber, secondNumber);
        }

        static void PrintFactorial(int firstNumber, int secondNumber)
        {
            double firstFactorial = 1;
            double secondFactorial = 1;

            for (int i = firstNumber; i > 0; i--)
            {
                firstFactorial = firstFactorial * i;
            }
            for (int i = secondNumber; i > 0; i--)
            {
                secondFactorial = secondFactorial * i;
            }

            double result = firstFactorial / secondFactorial;
            Console.WriteLine($"{result:f2}");
        }
    }
}
