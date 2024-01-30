using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = dimensions[0];
            int b = dimensions[1];

            string[,] matrix = new string[a, b];
            for (int row = 0; row < a; row++)
            {
                string[] els = Console.ReadLine().Split(' ');
                for (int col = 0; col < b; col++)
                    matrix[row, col] = els[col];
            }

            int squaresCount = 0;
            for (int row = 0; row < a - 1; row++)
            {
                for (int col = 0; col < b - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        squaresCount++;
                    }
                }
            }

            Console.WriteLine(squaresCount);
        }
    }
}
