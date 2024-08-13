using System;
using System.Linq;

namespace Wall_Derstroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int rowV = 0;
            int colV = 0;
            for (int i = 0; i < size; i++)
            {
                char[] array = Console.ReadLine().ToCharArray();
                for (int a = 0; a < size; a++)
                {
                    matrix[i, a] = array[a];
                    if (matrix[i, a] == 'V')
                    {
                        rowV = i;
                        colV = a;
                    }
                }
            }
            int pederas = 0;
            int numOfHoles = 0;
            int hitedRodes = 0;
            string command = Console.ReadLine();
            bool HitEl = false;
            while (command != "End")
            {
               pederas++;
                if (command == "up")
                {
                    if (rowV - 1 >= 0 && rowV - 1 <= size)
                    {
                        if (matrix[rowV - 1, colV] == '-')
                        {
                            matrix[rowV, colV] = '*';
                            numOfHoles++;
                            rowV--;
                            matrix[rowV, colV] = 'V';
                        }
                        else if (matrix[rowV - 1, colV] == 'R')
                        {
                            hitedRodes++;
                            Console.WriteLine("Vanko hit a rod!");

                        }
                        else if (matrix[rowV - 1, colV] == 'C')
                        {
                            numOfHoles++;
                            matrix[rowV, colV] = '*';
                           
                            HitEl = true;
                            matrix[rowV - 1, colV] = 'E';
                            numOfHoles++;
                            break;
                        }
                        else if (matrix[rowV - 1, colV] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV-1}, {colV}]!");
                            matrix[rowV, colV] = '*';
                            rowV = rowV - 1;
                        }
                       
                    }
                }
                else if (command == "down")
                {
                    if (rowV + 1 >= 0 && rowV + 1 <= size-1)
                    {
                        if (matrix[rowV + 1, colV] == '-')
                        {
                            matrix[rowV, colV] = '*';
                            numOfHoles++;
                            rowV++;
                            matrix[rowV, colV] = 'V';
                        }
                        else if (matrix[rowV + 1, colV] == 'R')
                        {
                            hitedRodes++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (matrix[rowV + 1, colV] == 'C')
                        {
                            numOfHoles++;
                            matrix[rowV, colV] = '*';
                           
                            HitEl = true;
                            matrix[rowV + 1, colV] = 'E';
                            numOfHoles++;
                            break;

                          
                        }
                        else if (matrix[rowV+ 1, colV] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV+1}, {colV}]!");
                            matrix[rowV, colV] = '*';
                            rowV = rowV + 1;
                        }

                    }
                }
                else if (command == "left")
                {
                    if (colV - 1 >= 0 && colV - 1 <= size)
                    {
                        if (matrix[rowV, colV - 1] == '-')
                        {
                            matrix[rowV, colV] = '*';
                            numOfHoles++;
                            colV--;
                            matrix[rowV, colV] = 'V';
                        }
                        else if (matrix[rowV, colV - 1] == 'R')
                        {
                            hitedRodes++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (matrix[rowV, colV - 1] == 'C')
                        {
                            numOfHoles++;
                            matrix[rowV, colV] = '*';
                          
                            HitEl = true;
                            matrix[rowV , colV- 1] = 'E';
                            numOfHoles++;
                            break;

                           
                        }
                        else if (matrix[rowV  , colV-1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV-1}]!");
                            matrix[rowV, colV] = '*';
                            colV  = colV - 1;
                        }
                       
                    }
                }
                else if (command == "right")
                {
                    if (colV + 1 >= 0 && colV + 1 <= size- 1)
                    {
                        if (matrix[rowV, colV + 1] == '-')
                        {
                            matrix[rowV, colV] = '*';
                            numOfHoles++;
                            colV++;
                            matrix[rowV, colV] = 'V';
                        }
                        else if (matrix[rowV, colV+ 1] == 'R')
                        {
                            hitedRodes++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (matrix[rowV, colV + 1] == 'C')
                        {
                            numOfHoles++;
                            matrix[rowV, colV] = '*';
                           
                            HitEl = true;
                            matrix[rowV , colV+ 1] = 'E';
                            numOfHoles++;
                            break;

                           
                        }
                        else if (matrix[rowV, colV + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV+1}]!");
                            matrix[rowV, colV] = '*';
                            colV = colV + 1;
                        }
                       
                    }
                }
                

                command = Console.ReadLine();
                if (command=="End")
                {
                    numOfHoles++;
                    
                    break;
                }



            }
           
            if (HitEl)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {numOfHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {numOfHoles} hole(s) and he hit only {hitedRodes} rod(s).");
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
    }
}
