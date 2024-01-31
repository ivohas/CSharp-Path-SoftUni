using System;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            string[,] matrix = new string[matrixSize, matrixSize];

            int minerRowIndex = 0;
            int minerColumnIndex = 0;

            int coalCount = 0;
            for(int row = 0; row < matrixSize; row++)
            {
                string[] els = Console.ReadLine().Split();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = els[col];
                    if (matrix[row, col] == "c")
                    {
                        coalCount++;
                    }
                    else if (matrix[row, col] == "s")
                    {
                        minerRowIndex = row;
                        minerColumnIndex = col;
                    }
                }
            }

            int coalFound = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "left" && minerColumnIndex - 1 >= 0)
                {
                    minerColumnIndex--;
                }
                else if (commands[i] == "right" && minerColumnIndex + 1 < matrixSize)
                {
                    minerColumnIndex++;
                }
                else if (commands[i] == "up" && minerRowIndex - 1 >= 0)
                {
                    minerRowIndex--;
                }
                else if (commands[i] == "down" && minerRowIndex + 1 < matrixSize)
                {
                    minerRowIndex++;
                }

                if (matrix[minerRowIndex, minerColumnIndex] == "c")
                {
                    matrix[minerRowIndex, minerColumnIndex] = "*";
                    coalFound++;
                    if (coalFound == coalCount)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRowIndex}, {minerColumnIndex})");
                        return;
                    }
                }
                else if (matrix[minerRowIndex, minerColumnIndex] == "e")
                {
                    Console.WriteLine($"Game over! ({minerRowIndex}, {minerColumnIndex})");
                    return;
                }
            }

            Console.WriteLine($"{coalCount - coalFound} coals left. ({minerRowIndex}, {minerColumnIndex})");
        }
    }
}
