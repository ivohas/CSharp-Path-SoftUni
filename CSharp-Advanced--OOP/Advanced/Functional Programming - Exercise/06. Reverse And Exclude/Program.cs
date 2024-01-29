using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int number = int.Parse(Console.ReadLine());

            Predicate<int> isDivisbleBy = num => num %number != 0;

            Action<List<int>> print = nums => Console.WriteLine(String.Join(" ", nums.Where(n => isDivisbleBy(n)).Reverse()));
            
            print(numbers);
        }
    }
}
