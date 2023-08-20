using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();

            int[] array2 = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != array2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }

            int sum = array.Sum();
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
