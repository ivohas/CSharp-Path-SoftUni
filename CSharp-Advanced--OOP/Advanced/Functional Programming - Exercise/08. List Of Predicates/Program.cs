using System;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool canBeDivided = false;

            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }


            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i % numbers[j] == 0)
                    {
                        canBeDivided = true;
                    }
                    else canBeDivided = false;
                }
                if(canBeDivided)
                        Console.Write(i + " ");
            }
        }
    }
}
