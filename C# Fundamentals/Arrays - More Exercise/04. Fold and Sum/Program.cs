using System;
using System.Linq;
namespace _04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = input.Length / 4;
            int[] output = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                output[i] = input[k - (i + 1)] + input[k + i];
                output[output.Length - 1 - i] = input[output.Length - 1 - i + k] + input[(output.Length - 1 - i) + (k + 2 * i + 1)];
            }
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
