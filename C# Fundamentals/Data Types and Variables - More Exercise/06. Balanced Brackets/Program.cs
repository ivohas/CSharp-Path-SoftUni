using System;
using System.Numerics;

namespace _06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            int openCount = 0;
            int closeCount = 0;

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                if (text == "(")
                {
                    openCount++;
                }
                else if (text == ")")
                {
                    closeCount++;
                    if (openCount - closeCount != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }
            if (closeCount == openCount)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
