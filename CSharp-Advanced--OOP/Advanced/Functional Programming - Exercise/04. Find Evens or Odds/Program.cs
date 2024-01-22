using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            (int lowNum, int highNum) = (boundaries[0], boundaries[1]);

            string oddOrEven = Console.ReadLine();

            Predicate<string> isOdd = s => s.Equals("odd");
            bool isOddBool = isOdd(oddOrEven);

            List<int> nums = new List<int>();
            while (lowNum <= highNum)
            {
                nums.Add(lowNum);
                lowNum++;
            }

            Action<List<int>> printOdd = nums =>
            {
                Console.WriteLine(String.Join(" ", nums.Where(x => x % 2 != 0)));
            };

            Action<List<int>> printEven = nums =>
            {
                Console.WriteLine(String.Join(" ", nums.Where(x => x % 2 == 0)));
            };

            if (isOddBool)
                printOdd(nums);
            else printEven(nums);
        }
    }
}
