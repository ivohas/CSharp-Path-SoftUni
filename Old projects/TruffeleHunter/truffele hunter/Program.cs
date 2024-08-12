using System;

namespace truffele_hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Black truffle -'B'

            //· Summer truffle -'S'

            //· White truffle -'W'
            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int boarTroffles = 0;
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] matrixElements = Console.ReadLine()
                    .Replace(" ", string.Empty).ToCharArray();
                for (int col = 0; col < matrixElements.Length; col++)
                {
                    matrix[row, col] = matrixElements[col];
                }
            }
            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] token = command.Split(' ');
                if (token[0] == "Collect")
                {
                    int row = int.Parse(token[1]);
                    int col = int.Parse(token[2]);
                    if (isValid(row, col, size))
                    {
                        if (matrix[row, col] == 'B')
                        {
                            blackTruffle++;

                        }
                        else if (matrix[row, col] == 'S')
                        {
                            summerTruffle += 1;
                        }
                        else if (matrix[row, col] == 'W')
                        {
                            whiteTruffle++;
                        }
                        matrix[row, col] = '-';
                    }

                }
                else if (token[0] == "Wild_Boar")
                {
                    int row = int.Parse(token[1]);
                    int col = int.Parse(token[2]);
                    string direction = token[3].Trim();

                    if (direction == "up")
                    {
                        while (isValid(row, col, size))
                        {
                            if (EatBoar(row, col, matrix, boarTroffles))
                            {
                                boarTroffles++;
                            }
                            row -= 2;
                        }
                    }
                    else if (direction == "down")
                    {
                        while (isValid(row, col, size))
                        {
                            if (EatBoar(row, col, matrix, boarTroffles))
                            {
                                boarTroffles++;
                            }
                            row += 2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (isValid(row, col, size))
                        {
                            if (EatBoar(row, col, matrix, boarTroffles))
                            {
                                boarTroffles++;
                            }
                            col -= 2;
                        }
                    }
                    else if (direction == "right")
                    {

                        while (isValid(row, col, size))
                        {
                            if (EatBoar(row, col, matrix, boarTroffles))
                            {
                                boarTroffles++;
                            }
                            
                            col += 2;
                        }

                    }
                }
                //while цикъл
                command = Console.ReadLine();
            }


            // what Piter had collected
            Console.WriteLine($"Peter manages to harvest {blackTruffle} black" +
                $", {summerTruffle} summer" +
                $", and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTroffles} truffles.");
            // what matrix lookks like after the changes
            PrintMatrix(size, size, matrix);
            // main method
        }

        private static bool EatBoar(int row, int col, char[,] matrix, int boarTr)
        {
            if (matrix[row, col] == '-')
            {
                return false;
            }
            else
            {
               
                matrix[row, col] = '-';
                return true;
            }
        }

        public static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (cols - 1 == col)
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


        private static bool isValid(int row, int col, int size)
        {
            if (row >= 0 && row < size &&
                col >= 0 && col < size)
            {
                return true;
            }
            return false;
        }
    }

}

