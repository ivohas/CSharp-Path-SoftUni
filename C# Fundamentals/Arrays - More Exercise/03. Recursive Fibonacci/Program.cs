using System;

namespace _03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
                int positionInFibonacciSequence = int.Parse(Console.ReadLine());
                int[] fibonacciSequence = new int[50];

                fibonacciSequence[0] = 1;
                fibonacciSequence[1] = 1;

                if (positionInFibonacciSequence > 2)
                {
                    for (int i = 2; i < positionInFibonacciSequence; i++)
                    {
                        fibonacciSequence[i] = fibonacciSequence[i - 1] + fibonacciSequence[i - 2];
                    }
                }
                Console.WriteLine(fibonacciSequence[positionInFibonacciSequence - 1]);
        }
    }
}
