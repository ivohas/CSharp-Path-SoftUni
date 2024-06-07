using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mesure= Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            // Get the size of the matrix
            int[,] matrix = new int[mesure[0], mesure[1]];
            // Create the marix
            Console.WriteLine(mesure[0]);
            // Write the numbers of its collums and rows
            Console.WriteLine(mesure[1]);
            // Use method to fill it
            FillMatrix(matrix);
            int sum = 0;
            SumValueOfMatrix(matrix,sum);
            Console.WriteLine(sum);
        }

        private static void SumValueOfMatrix(int[,] matrix, int sum)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                     sum=+matrix[row,col];
                }
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowDate = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++) 
                {
                    matrix[row, col] = rowDate[col];
                }
            }
        }
    }
}
