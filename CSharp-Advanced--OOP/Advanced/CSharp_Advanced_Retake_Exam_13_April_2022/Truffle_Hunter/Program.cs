using System;
using System.Linq;

namespace Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] els = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < els.Length; col++)
                {
                    matrix[row, col] = els[col];
                }
            }

            int blackCount = 0;
            int summerCount = 0;
            int whiteCount = 0;
            int boarTruffles = 0;
            while (true)
            {
                string[] command = Console.ReadLine().Split();

                string cmdType = command[0];

                int row = 0;
                int col = 0;
                if (string.Join(" ", command) != "Stop the hunt")
                {
                    row = int.Parse(command[1]);
                    col = int.Parse(command[2]);
                }

                if (cmdType == "Collect")
                {
                    if (row < n && row >= 0 && col < n && col >= 0)
                    {
                        if (matrix[row, col] != '-')
                        {
                            if (matrix[row, col] == 'B')
                            {
                                blackCount++;
                            }
                            else if (matrix[row, col] == 'S')
                            {
                                summerCount++;
                            }
                            else if (matrix[row, col] == 'W')
                            {
                                whiteCount++;
                            }
                            matrix[row, col] = '-';
                        }
                    }
                }
                else if (cmdType == "Wild_Boar")
                {
                    string direction = command[3];
                    int index = 0;
                    if (direction == "up")
                    {
                        index = row;
                        if (matrix[index, col] != '-')
                        {
                            boarTruffles++;
                        }
                        matrix[row, col] = '-';
                        while (true)
                        {
                            index -= 2;
                            if (index >= 0)
                            {
                                if (matrix[index, col] != '-')
                                {
                                    boarTruffles++;
                                }
                                matrix[index, col] = '-';
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        index = row;
                        if (matrix[index, col] != '-')
                        {
                            boarTruffles++;
                        }
                        matrix[row, col] = '-';
                        while (true)
                        {
                            index += 2;
                            if (index < n)
                            {
                                if (matrix[index, col] != '-')
                                {
                                    boarTruffles++;
                                }
                                matrix[index, col] = '-';
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        index = col;
                        if (matrix[row, index] != '-')
                        {
                            boarTruffles++;
                        }
                        matrix[row, col] = '-';
                        while (true)
                        {
                            index -= 2;
                            if (index >= 0)
                            {
                                if (matrix[row, index] != '-')
                                {
                                    boarTruffles++;
                                }
                                matrix[row, index] = '-';
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        index = col;
                        if (matrix[row, index] != '-')
                        {
                            boarTruffles++;
                        }
                        matrix[row, col] = '-';
                        while (true)
                        {
                            index += 2;
                            if (index < n)
                            {
                                if (matrix[row, index] != '-')
                                {
                                    boarTruffles++;
                                }
                                matrix[row, index] = '-';
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (string.Join(" ", command) == "Stop the hunt")
                {
                    break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackCount} black, {summerCount} summer, and {whiteCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write((char)matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
