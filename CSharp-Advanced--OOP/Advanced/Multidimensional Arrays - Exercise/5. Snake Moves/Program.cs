using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            (int N, int M) = (dimensions[0], dimensions[1]);

            char[,] matrix = new char[N, M];
            string snake = Console.ReadLine();
            int s = 0;

            for (int r = 0; r < N; r++)
            {
                if (r % 2 == 0)
                {
                    for (int c = 0; c < M; c++)
                    {
                        matrix[r, c] =  snake[s];
                        s++;
                        if (s >= snake.Length)
                        {
                            s = 0;
                        }
                    }
                }
                else
                {
                    for (int c = M - 1; c >= 0; c--)
                    {
                        matrix[r, c] = snake[s];
                        s++;
                        if (s >= snake.Length)
                        {
                            s = 0;
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);

                }

                Console.WriteLine();
            }
        }
    }
}
