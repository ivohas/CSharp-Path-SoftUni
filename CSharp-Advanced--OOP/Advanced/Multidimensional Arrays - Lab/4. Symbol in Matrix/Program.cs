using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] els = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = els[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool found = false; 
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (matrix[r, c] == symbol)
                    {
                        Console.WriteLine($"({r}, {c})");
                        found = true;
                        goto HERE;
                    }
                }
            }
            HERE:
            if (!found)
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
