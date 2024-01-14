using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < values.Length; i++)
                set.Add(values[i]);

            Func<HashSet<int>, int> printMinNumber = minNumber => set.Min();
            Console.WriteLine(printMinNumber(set));
        }
    }
}
