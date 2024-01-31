using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main()
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

            long sum = 0;
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    sum+= matrix[row,col];
                }
            }

            Console.WriteLine(rowsCount);
            Console.WriteLine(colsCount);
            Console.WriteLine(sum);
        }
    }
}
