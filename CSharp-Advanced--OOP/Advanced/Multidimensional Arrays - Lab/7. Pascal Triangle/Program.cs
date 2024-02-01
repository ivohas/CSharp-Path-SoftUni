using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];
            for (int row = 0; row < n; row++)
            {
                triangle[row] = new long[row+1];
                triangle[row][0] = 1;
                for (int col = 1; col < row; col++)
                {
                    triangle[row][col] = 
                        triangle[row - 1][col - 1] + 
                        triangle[row - 1][col];
                }
                triangle[row][row] = 1;
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                Console.WriteLine(String.Join(" ", triangle[row]));
            }
        }
    }
}
