using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }
                else numbers[num]++;
            }

            foreach (var num in numbers)
            {
                if (num.Value % 2 != 0)
                {
                    Console.WriteLine(num.Key);
                    break;
                }
            }
        }
    }
}
