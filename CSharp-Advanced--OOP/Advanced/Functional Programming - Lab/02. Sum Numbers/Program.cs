using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());
        }
    }
}
