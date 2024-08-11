using System;
using System.Linq;

namespace TheBattleOfFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                char[] r = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();

                for (int a = 0; a < size; a++)
                {
                    matrix[i, a] = r[a];
                }
            }

            int rowA = 0;
            int colA = 0;
            for (int i = 0; i < size; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    if (matrix[i, a] == 'A')
                    {
                        rowA = i;
                        colA = a;
                    }
                }
            }
            int armorCount = 0;
            string command = null;
            for (int i = armor; i > 0; i--)
            {
                command = Console.ReadLine();
                armorCount++;
                string[] token = command.Split().ToArray();
                string direction = token[0];
                int rowOrcs = int.Parse(token[1]);
                int colOrcs = int.Parse(token[2]);
                matrix[rowOrcs, colOrcs] = 'O';
                switch (direction)
                {
                    case "up":
                        if (rowA - 1 >= 0 && rowA <= size)
                        {
                            Movement(i, matrix, rowA, colA);
                            if (i==0)
                            {
                                break;
                            }
                        }

                        break;
                    case "down":
                        if (rowA + 1 >= 0 && rowA < size)
                        {
                            if (matrix[rowA + 1, colA] == 'O')
                            {

                                matrix[rowA + 1, colA] = 'X';
                                matrix[rowA, colA] = '-';
                                rowA = rowA + 1;
                                i = 0;
                                break;
                            }
                            matrix[rowA, colA] = '-';
                            rowA += 1;
                            if (matrix[rowA, colA] == 'M')
                            {
                                matrix[rowA, colA] = '-';
                                i = 0;
                            }
                            else
                            {
                                matrix[rowA, colA] = 'A';
                            }


                        }
                        break;
                    case "left":
                        if (colA - 1 > 0 && colA <= size)
                        {
                            if (matrix[rowA, colA - 1] == 'O')
                            {

                                matrix[rowA, colA - 1] = 'X';
                                matrix[rowA, colA] = '-';
                                colA = colA - 1;
                                i = 0;
                                break;
                            }
                            matrix[rowA, colA] = '-';
                            colA -= 1;
                            if (matrix[rowA, colA] == 'M')
                            {
                                matrix[rowA, colA] = '-';
                                i = 0;
                            }
                            else
                            {
                                matrix[rowA, colA] = 'A';
                            }


                        }
                        break;
                    case "right":
                        if (colA + 1 >= 0 && colA < size)
                        {
                            if (matrix[rowA, colA + 1] == 'O')
                            {

                                matrix[rowA, colA + 1] = 'X';
                                matrix[rowA, colA] = '-';
                                colA = colA + 1;
                                i = 0;
                                break;
                            }
                            matrix[rowA, colA] = '-';
                            colA += 1;
                            if (matrix[rowA, colA] == 'M')
                            {
                                matrix[rowA, colA] = '-';
                                i = 0;
                            }
                            else
                            {
                                matrix[rowA, colA] = 'A';
                            }


                        }
                        break;
                }

            }
            bool check = true;
            for (int i = 0; i < size; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    if (matrix[i, a] == 'A')
                    {
                        rowA = i;
                        colA = a;
                        matrix[i, a] = 'X';
                    }
                    if (matrix[i, a] == 'M')
                    {
                        check = false;
                    }
                }
            }
            int totalArmor = armor - armorCount;
            if (check)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {totalArmor}");

            }
            else
            {
                Console.WriteLine($"The army was defeated at {rowA};{colA}.");

            }
            for (int i = 0; i < size; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    Console.Write(matrix[i, a]);
                }
                Console.WriteLine();
            }
        }

        private static void Movement(int i, char[,] matrix, int rowA, int colA)
        {
            if (matrix[rowA - 1, colA] == 'O')
            {

                matrix[rowA - 1, colA] = 'X';
                matrix[rowA, colA] = '-';
                rowA = rowA - 1;
                i = 0;
                return;
            }
            
                matrix[rowA, colA] = '-';
                rowA -= 1;
                if (matrix[rowA, colA] == 'M')
                {
                    matrix[rowA, colA] = '-';
                    i = 0;
                }
                else
                {
                    matrix[rowA, colA] = 'A';
                }
            


        }
    }
}
