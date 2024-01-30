using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            (int rowsCount, int colsCount) = (dimensions[0], dimensions[1]);

            string[,] matrix = new string[rowsCount, colsCount];
            for (int r = 0; r < rowsCount; r++)
            {
                string[] els = Console.ReadLine().Split(' ');
                for (int c = 0; c < colsCount; c++)
                    matrix[r, c] = els[c];
            }

            string command = Console.ReadLine();
            while (command != "END")
            {

                if (!ValidateMatrix(command, rowsCount, colsCount))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    string[] cmdArgs = command.Split(' ');
                    int orgR = int.Parse(cmdArgs[1]);
                    int orgC = int.Parse(cmdArgs[2]);
                    int swapR = int.Parse(cmdArgs[3]);
                    int swapC = int.Parse(cmdArgs[4]);

                    string orgValue = matrix[orgR, orgC];
                    string swapValue = matrix[swapR, swapC];

                    matrix[orgR, orgC] = swapValue;
                    matrix[swapR, swapC] = orgValue;

                    PrintMatrix(matrix);
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");

                }

                Console.WriteLine();
            }
        }

        private static bool ValidateMatrix(string input, int rows, int cols)
        {
            string[] cmdArgs = input.Split(' ');
            if (cmdArgs[0] == "swap" && cmdArgs.Length == 5)
            {
                int orgR = int.Parse(cmdArgs[1]);
                int orgC = int.Parse(cmdArgs[2]);
                int swapR = int.Parse(cmdArgs[3]);
                int swapC = int.Parse(cmdArgs[4]);

                if (orgR >= 0 && orgR < rows &&
                    orgC >= 0 && orgC < cols &&
                    swapR >= 0 && swapR < rows &&
                    swapC >= 0 && swapC < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
