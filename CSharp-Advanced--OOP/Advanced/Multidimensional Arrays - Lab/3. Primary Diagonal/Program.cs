using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            for (int r = 0; r < n; r++)
            {
                int[] colElements = Console.ReadLine()
                        .Split(' ').Select(int.Parse).ToArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            int sum = 0;
            for (int r = 0; r < n; r++)
            {
                sum += matrix[r, r];
            }
            Console.WriteLine(sum); 
        }
    }
}
