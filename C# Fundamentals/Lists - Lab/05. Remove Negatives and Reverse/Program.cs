using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            numbers.RemoveAll(x => x < 0);

            numbers.Reverse();

            if (numbers.Count < 1)
            {
                Console.WriteLine("empty");
                return;
            }
            else Console.WriteLine(String.Join(" ", numbers));
            
        }
    }
}