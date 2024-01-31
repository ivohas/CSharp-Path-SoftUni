using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
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
                int[] colElements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            long[] colSums = new long[colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    colSums[col] += matrix[row, col];
                }
            }

            for (int col = 0; col < colsCount; col++)
            {
                Console.WriteLine(colSums[col]);
            }
        }
    }
}
