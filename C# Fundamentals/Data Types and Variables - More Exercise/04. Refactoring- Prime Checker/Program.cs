using System;

namespace _04._Refactoring__Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                bool isItTrue = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isItTrue = false;
                        break;
                    }
                }
                if (isItTrue)
                {
                    Console.WriteLine($"{i} -> true");
                }
                else
                {
                    Console.WriteLine($"{i} -> false");
                }
            }

        }
    }
}
