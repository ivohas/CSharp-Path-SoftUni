using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int [,] matrix = new int[n, n]; 
            for (int r = 0; r < n; r++)
            {
                int[] els = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = els[c];
                }
            }

            Stack<int> indexes = new Stack<int>(Console.ReadLine().Split(new char[] { ',', ' ' }).Select(int.Parse));
            indexes = new Stack<int>(indexes);

            int a = indexes.Count() / 2;

            for (int i = 0; i < indexes.Count() / 2; i++)
            {
                int r = indexes.Pop();
                int c = indexes.Pop();
                int currNumber = matrix[r, c];
                if (matrix[r, c] > 0)
                {
                    if (r - 1 >= 0 && c - 1 >= 0 && matrix[r - 1, c - 1] > 0)
                        matrix[r - 1, c - 1] -= currNumber;
                    if (c - 1 >= 0 && matrix[r, c - 1] > 0)
                        matrix[r, c - 1] -= matrix[r, c];
                    if (r + 1 < n && c - 1 >= 0 && matrix[r + 1, c - 1] > 0)
                        matrix[r + 1, c - 1] -= currNumber;

                    if (r + 1 < n && matrix[r + 1, c] > 0)
                        matrix[r + 1, c] -= currNumber;
                    if (r - 1 >= 0 && matrix[r - 1, c] > 0)
                        matrix[r - 1, c] -= currNumber;

                    if (r - 1 >= 0 && c + 1 < n && matrix[r - 1, c + 1] > 0)
                        matrix[r - 1, c + 1] -= currNumber;
                    if (c + 1 < n && matrix[r, c + 1] > 0)
                        matrix[r, c + 1] -= matrix[r, c];
                    if (r + 1 < n && c + 1 < n && matrix[r + 1, c + 1] > 0)
                        matrix[r + 1, c + 1] -= currNumber;

                    matrix[r, c] = 0;
                }
            }

            int aliveCells = 0;
            int sum = 0;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (matrix[r, c] > 0)
                    {
                        aliveCells++;
                        sum += matrix[r, c];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine(); ;
            }
        }
    }
}
