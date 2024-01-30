using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int r = 0; r < rows; r++)
            {
                jagged[r] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            for (int r = 0; r < rows - 1; r++)
            {
                if (jagged[r].Length == jagged[r + 1].Length)
                {
                    jagged[r] = jagged[r].Select(el => el * 2).ToArray();
                    jagged[r + 1] = jagged[r + 1].Select(el => el * 2).ToArray();
                }
                else
                {
                    jagged[r] = jagged[r].Select(el => el / 2).ToArray();
                    jagged[r + 1] = jagged[r + 1].Select(el => el / 2).ToArray();
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmdArgs = input.Split(' ');
                string command = cmdArgs[0];

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (command == "Add")
                {
                    if (row >= 0 && row < rows && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] += value;

                    }
                }
                else if (command == "Subtract")
                {

                    if (row >= 0 && row < rows && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] -= value;

                    }
                }

                input = Console.ReadLine();
            }

            for (int r = 0; r < rows; r++)
            {
                Console.WriteLine(String.Join(' ', jagged[r]));
            }
        }
    }
}
