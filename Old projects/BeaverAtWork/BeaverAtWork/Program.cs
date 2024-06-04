using System;
using System.Collections.Generic;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            ReadMatrix(size, matrix);
            int r = 0;
            int c = 0;
            int beaverSticks = 0;
            int branchesInPond = 0;
            for (int row = 0; row < size; row++)
            {
                for (int colums = 0; colums < size; colums++)
                {

                    if (matrix[row, colums] == 'B')
                    {
                        r = row;
                        c = colums;
                    }
                    if (char.IsLetter(matrix[row, colums]) && char.IsLower(matrix[row, colums]))
                    {
                        branchesInPond++;
                    }
                }
            }
            List<char> collected = new List<char>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "up")
                {
                    matrix[r, c] = '-';
                    r -= 1;
                    if (r >= 0 && r < size-1 && c >= 0 && c < size-1)
                    {

                        char box = matrix[r, c];
                        matrix[r, c] = '-';
                        if (char.IsLetter(box) && char.IsLower(box))
                        {
                            collected.Add(box);
                        }
                        else if (box == 'F')
                        {
                            c = size - 1;
                            box = matrix[r, c];
                            matrix[r, c] = '-';
                            if (char.IsLetter(box) && char.IsLower(box))
                            {
                                collected.Add(box);
                            }
                        }
                    }
                    if (command == "down")
                    {
                        matrix[r, c] = '-';
                        r += 1;
                        if (r >= 0 && r < size-1 && c >= 0 && c < size-1)
                        {

                            char box = matrix[r, c];
                            matrix[r, c] = '-';
                            if (char.IsLetter(box) && char.IsLower(box))
                            {
                                collected.Add(box);
                            }
                            else if (box == 'F')
                            {
                                c = size - 1;
                                box = matrix[r, c];
                                matrix[r, c] = '-';
                                if (char.IsLetter(box) && char.IsLower(box))
                                {
                                    collected.Add(box);
                                }
                            }
                        }


                    }
                    if (command == "left")
                    {
                        matrix[r, c] = '-';
                        c-= 1;
                        if (r >= 0 && r < size-1 && c >= 0 && c < size-1)
                        {

                            char box = matrix[r, c];
                            matrix[r, c] = '-';
                            if (char.IsLetter(box) && char.IsLower(box))
                            {
                                collected.Add(box);
                            }
                            else if (box == 'F')
                            {
                                c = size - 1;
                                box = matrix[r, c];
                                matrix[r, c] = '-';
                                if (char.IsLetter(box) && char.IsLower(box))
                                {
                                    collected.Add(box);
                                }
                            }
                        }


                    }
                    if (command == "right")
                    {
                        matrix[r, c] = '-';
                        c += 1;
                        if (r >= 0 && r < size-1 && c >= 0 && c < size-1)
                        {

                            char box = matrix[r, c];
                            matrix[r, c] = '-';
                            if (char.IsLetter(box) && char.IsLower(box))
                            {
                                collected.Add(box);
                            }
                            else if (box == 'F')
                            {
                                c = size - 1;
                                box = matrix[r, c];
                                matrix[r, c] = '-';
                                if (char.IsLetter(box) && char.IsLower(box))
                                {
                                    collected.Add(box);
                                }
                            }
                        }


                    }
                    command = Console.ReadLine();
                }

                beaverSticks = collected.Count;
                if (beaverSticks <= branchesInPond)
                {
                    Console.WriteLine($"The Beaver failed to collect every wood branch." +
                        $" There are {branchesInPond - beaverSticks} branches left.");
                }
                else
                {
                    Console.WriteLine($"The Beaver successfully collect {beaverSticks} wood branches: "
                        + String.Join(",", collected));
                }
                PrintMatrix(size, size, matrix);

            }
            static void PrintMatrix(int rows, int cols, char[,] matrix)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (col == cols - 1)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        else
                        {
                            Console.Write(matrix[row, col] + " ");

                        }

                    }
                    Console.WriteLine();
                }
            }


            static void BeaverPosition(char[,] matrix, int c, int r)
            {
                matrix[r, c] = '-';
            }

            static void ReadMatrix(int rows, char[,] matrix)
            {
                for (int row = 0; row < rows; row++)
                {
                    char[] matrixElements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
                    for (int col = 0; col < matrixElements.Length; col++)
                    {
                        matrix[row, col] = matrixElements[col];
                    }
                }
            }
        }
    }
}
