using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Bunny
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public Bunny(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            (int rowCount, int colCount) = (dimensions[0], dimensions[1]);
            char[,] jagged = new char[rowCount, colCount];


            List<Bunny> bunnies = new List<Bunny>();

            int playerRowIndex = 0;
            int playerColumnIndex = 0;

            int bunnyCount = 0;

            for (int row = 0; row < rowCount; row++)
            {
                string els = Console.ReadLine();
                for (int col = 0; col < colCount; col++)
                {
                    jagged[row, col] = els[col];
                    if (jagged[row, col] == 'B')
                    {
                        Bunny bunny = new Bunny(row, col);
                        bunnies.Add(bunny);
                        bunnyCount++;
                    }
                    else if (jagged[row, col] == 'P')
                    {
                        playerRowIndex = row;
                        playerColumnIndex = col;
                    }
                }
            }
            string commands = Console.ReadLine();

            int finalPlayerRowIndex = 0;
            int finalPlayerColumnIndex = 0;
            bool playerEscaped = false;
            bool playerAlive = true;

            for (int i = 0; i < commands.Length; i++)
            {
                if (playerEscaped == false && playerAlive)
                {
                    if (commands[i] == 'L' && playerColumnIndex - 1 >= 0)
                    {
                        jagged[playerRowIndex, playerColumnIndex] = '.';
                        playerColumnIndex--;
                    }
                    else if (commands[i] == 'R' && playerColumnIndex + 1 < colCount)
                    {
                        jagged[playerRowIndex, playerColumnIndex] = '.';
                        playerColumnIndex++;
                    }
                    else if (commands[i] == 'U' && playerRowIndex - 1 >= 0)
                    {
                        jagged[playerRowIndex, playerColumnIndex] = '.';
                        playerRowIndex--;
                    }
                    else if (commands[i] == 'D' && playerRowIndex + 1 < rowCount)
                    {
                        jagged[playerRowIndex, playerColumnIndex] = '.';
                        playerRowIndex++;
                    }
                    else if (commands[i] == 'L' || commands[i] == 'R' || commands[i] == 'U' || commands[i] == 'D')
                    {
                        jagged[playerRowIndex, playerColumnIndex] = '.';
                        finalPlayerRowIndex = playerRowIndex;
                        finalPlayerColumnIndex = playerColumnIndex;
                        playerEscaped = true;
                    }
                }
                if (playerEscaped == false && playerAlive)
                {
                    jagged[playerRowIndex, playerColumnIndex] = 'P';
                }


                int BC = bunnies.Count;
                if (playerAlive)
                {
                    for (int k = 0; k < BC; k++)
                    {
                        Bunny currentBunny = bunnies[k];
                        int currBunnyRowIndex = currentBunny.RowIndex;
                        int currBunnyColumnIndex = currentBunny.ColumnIndex;
                        if (currBunnyColumnIndex + 1 < colCount)
                        {
                            if (jagged[currentBunny.RowIndex, currentBunny.ColumnIndex + 1] == 'P')
                            {
                                playerAlive = false;
                            }
                            else
                            {
                                if (!bunnies.Contains(bunnies.Find(x => x.RowIndex == currBunnyRowIndex && x.ColumnIndex == currBunnyColumnIndex + 1)))
                                    bunnies.Add(new Bunny(currBunnyRowIndex, currBunnyColumnIndex + 1));
                            }
                            jagged[currBunnyRowIndex, currBunnyColumnIndex + 1] = 'B';
                        }
                        if (currBunnyColumnIndex - 1 >= 0)
                        {
                            if (jagged[currentBunny.RowIndex, currBunnyColumnIndex - 1] == 'P')
                            {
                                playerAlive = false;
                            }
                            else
                            {
                                if (!bunnies.Contains(bunnies.Find(x => x.RowIndex == currBunnyRowIndex && x.ColumnIndex == currBunnyColumnIndex - 1)))
                                    bunnies.Add(new Bunny(currBunnyRowIndex, currBunnyColumnIndex - 1));
                            }
                            jagged[currBunnyRowIndex, currBunnyColumnIndex - 1] = 'B';
                        }
                        if (currBunnyRowIndex + 1 < rowCount)
                        {
                            if (jagged[currentBunny.RowIndex + 1, currentBunny.ColumnIndex] == 'P')
                            {
                                playerAlive = false;
                            }
                            else
                            {
                                if (!bunnies.Contains(bunnies.Find(x => x.RowIndex == currBunnyRowIndex + 1 && x.ColumnIndex == currBunnyColumnIndex + 1)))
                                    bunnies.Add(new Bunny(currBunnyRowIndex + 1, currBunnyColumnIndex));
                            }
                            jagged[currBunnyRowIndex + 1, currBunnyColumnIndex] = 'B';
                        }
                        if (currBunnyRowIndex - 1 >= 0)
                        {
                            if (jagged[currentBunny.RowIndex - 1, currentBunny.ColumnIndex] == 'P')
                            {
                                playerAlive = false;
                            }
                            else
                            {
                                if (!bunnies.Contains(bunnies.Find(x => x.RowIndex == currBunnyRowIndex - 1 && x.ColumnIndex == currBunnyColumnIndex)))
                                    bunnies.Add(new Bunny(currBunnyRowIndex - 1, currBunnyColumnIndex));
                            }
                            jagged[currBunnyRowIndex - 1, currBunnyColumnIndex] = 'B';
                        }
                    }
                }

            }

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    Console.Write(jagged[r, c]);
                }
                Console.WriteLine();
            }

            if (playerAlive)
            {
                Console.WriteLine($"won: {finalPlayerRowIndex} {finalPlayerColumnIndex}");
            }
            else Console.WriteLine($"dead: {playerRowIndex} {playerColumnIndex}");
        }
    }
}
