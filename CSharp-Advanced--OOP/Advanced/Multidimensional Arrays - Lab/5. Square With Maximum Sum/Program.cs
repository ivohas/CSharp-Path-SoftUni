using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read the matrix deminesions
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            (int rowsCount, int colsCount) = (dimensions[0], dimensions[1]);

            // read the numbers of the matrix
            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            long maxSum = long.MinValue;
            string bestSquare2x2 = string.Empty;
            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    long sum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestSquare2x2 =
                        matrix[row, col] + " " + matrix[row, col + 1] + "\r\n" +
                        matrix[row + 1, col] + " " + matrix[row + 1, col + 1];
                    }
                }
            }

            Console.WriteLine(bestSquare2x2);
            Console.WriteLine(maxSum);
        }
    }
}
