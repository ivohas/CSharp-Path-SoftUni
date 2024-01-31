using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split(' ').Select(int.Parse).ToArray();
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                string cmd = input[0];

                if (cmd == "Add" || cmd == "Subtract")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int val = int.Parse(input[3]);
                    if (cmd == "Subtract")
                    {
                        val = -val;
                    }
                    if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] += val;

                    }
                    else Console.WriteLine("Invalid coordinates");
                }
                else if (cmd == "END")
                {
                    break;
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(String.Join(" ", jagged[row]));
            }
        }
    }
}
