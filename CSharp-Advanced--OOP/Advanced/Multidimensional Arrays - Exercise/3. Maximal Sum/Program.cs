using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = numbers[0];
            int M = numbers[1];

            int[,] matrix = new int[N, M];
            for (int ro = 0; ro < N; ro++)
            {
                int[] els = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < M; col++)
                    matrix[ro, col] = els[col];
            }

            int bestMatrixSum = int.MinValue;
            string bestMatrix = string.Empty;
            for (int r = 0; r < N - 2; r++)
            {
                for (int c = 0; c < M - 2; c++)
                {
                    if (matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2] +
                        matrix[r + 1, c] + matrix[r + 1, c + 1] + matrix[r + 1, c + 2] +
                        matrix[r + 2, c] + matrix[r + 2, c + 1] + matrix[r + 2, c + 2]
                        >= bestMatrixSum)

                    {
                        bestMatrixSum = matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2] +
                        matrix[r + 1, c] + matrix[r + 1, c + 1] + matrix[r + 1, c + 2] +
                        matrix[r + 2, c] + matrix[r + 2, c + 1] + matrix[r + 2, c + 2];

                        bestMatrix = matrix[r, c] + " " + matrix[r, c + 1] + " " + matrix[r, c + 2] + "\r\n" +
                        matrix[r + 1, c] + " " + matrix[r + 1, c + 1] + " " + matrix[r + 1, c + 2] + "\r\n" +
                        matrix[r + 2, c] + " " + matrix[r + 2, c + 1] + " " + matrix[r + 2, c + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {bestMatrixSum}");
            Console.WriteLine(bestMatrix);
        }
    }
    }
}
