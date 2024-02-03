using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3).ToList();
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
