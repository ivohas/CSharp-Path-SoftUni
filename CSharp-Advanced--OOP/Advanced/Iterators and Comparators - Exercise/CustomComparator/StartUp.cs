using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> sortFunction = (x, y) =>
            (x % 2 == 0 && y % 2 != 0) ? -1 :
            (x % 2 != 0 && y % 2 == 0) ? 1 : x > y ? 1 : x < y ? -1 : 0;

            Array.Sort(numbers, (x, y) => sortFunction(x, y));
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}