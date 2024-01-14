using System;
using System.Linq;

namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main()
        {
            int golemina = int.Parse(Console.ReadLine());
            char[,] stena = new char[golemina, golemina];
            int mqstonaIvanRow = 0;
            int mqstonaIvanCol = 0;
            for (int row = 0; row < golemina; row++)
            {
                char[] elementi = Console.ReadLine().ToCharArray();
                for (int col = 0; col < golemina; col++)
                {
                    stena[row, col] = elementi[col];
                    if (stena[row, col] == 'V')
                    {
                        mqstonaIvanRow = row;
                        mqstonaIvanCol = col;
                    }
                }
            }
            bool barnalLiEToka;
            barnalLiEToka = false;
            int dupkiPoMasata = 0;
            int pipnatiJici = 0;
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "up")
                {
                    if (mqstonaIvanRow - 1 >= 0 && mqstonaIvanRow < golemina)
                    {
                        if (stena[mqstonaIvanRow - 1, mqstonaIvanCol] == '-')
                        {
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            dupkiPoMasata++;
                            mqstonaIvanRow-=1;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = 'V';
                        }
                        else if (stena[mqstonaIvanRow - 1, mqstonaIvanCol] == 'R')
                        {
                            pipnatiJici++;
                            Console.WriteLine("Vanko hit a rod!");

                        }
                        else if (stena[mqstonaIvanRow - 1, mqstonaIvanCol] == 'C')
                        {
                            dupkiPoMasata++;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';

                            barnalLiEToka = true;
                            stena[mqstonaIvanRow - 1, mqstonaIvanCol] = 'E';
                            dupkiPoMasata++;
                            break;
                        }
                        else if (stena[mqstonaIvanRow - 1, mqstonaIvanCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{mqstonaIvanRow - 1}, {mqstonaIvanCol}]!");
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            mqstonaIvanRow = mqstonaIvanRow - 1;
                        }

                    }
                }
                else if (command == "down")
                {
                    if (mqstonaIvanRow + 1 >= 0 && mqstonaIvanRow + 1 <= golemina - 1)
                    {
                        if (stena[mqstonaIvanRow + 1, mqstonaIvanCol] == '-')
                        {
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            dupkiPoMasata++;
                            mqstonaIvanRow++;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = 'V';
                        }
                        else if (stena[mqstonaIvanRow + 1, mqstonaIvanCol] == 'R')
                        {
                            pipnatiJici++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (stena[mqstonaIvanRow + 1, mqstonaIvanCol] == 'C')
                        {
                            dupkiPoMasata++;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';

                            barnalLiEToka = true;
                            stena[mqstonaIvanRow + 1, mqstonaIvanCol] = 'E';
                            dupkiPoMasata++;
                            break;
                        }
                        else if (stena[mqstonaIvanRow + 1, mqstonaIvanCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{mqstonaIvanRow + 1}, {mqstonaIvanCol}]!");
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            mqstonaIvanRow = mqstonaIvanRow + 1;
                        }

                    }
                }
                else if (command == "left")
                {
                    if (mqstonaIvanCol - 1 >= 0 && mqstonaIvanCol - 1 <= golemina)
                    {
                        if (stena[mqstonaIvanRow, mqstonaIvanCol - 1] == '-')
                        {
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            dupkiPoMasata++;
                            mqstonaIvanCol--;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = 'V';
                        }
                        else if (stena[mqstonaIvanRow, mqstonaIvanCol - 1] == 'R')
                        {
                            pipnatiJici++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (stena[mqstonaIvanRow, mqstonaIvanCol - 1] == 'C')
                        {
                            dupkiPoMasata++;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';

                            barnalLiEToka = true;
                            stena[mqstonaIvanRow, mqstonaIvanCol - 1] = 'E';
                            dupkiPoMasata++;
                            break;
                        }
                        else if (stena[mqstonaIvanRow, mqstonaIvanCol - 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{mqstonaIvanRow}, {mqstonaIvanCol - 1}]!");
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            mqstonaIvanCol = mqstonaIvanCol - 1;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (mqstonaIvanCol + 1 >= 0 && mqstonaIvanCol + 1 <= golemina - 1)
                    {
                        if (stena[mqstonaIvanRow, mqstonaIvanCol + 1] == '-')
                        {
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            dupkiPoMasata++;
                            mqstonaIvanCol++;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = 'V';
                        }
                        else if (stena[mqstonaIvanRow, mqstonaIvanCol + 1] == 'R')
                        {
                            pipnatiJici++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (stena[mqstonaIvanRow, mqstonaIvanCol + 1] == 'C')
                        {
                            dupkiPoMasata++;
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';

                            barnalLiEToka = true;
                            stena[mqstonaIvanRow, mqstonaIvanCol + 1] = 'E';
                            dupkiPoMasata++;
                            break;
                        }
                        else if (stena[mqstonaIvanRow, mqstonaIvanCol + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{mqstonaIvanRow}, {mqstonaIvanCol + 1}]!");
                            stena[mqstonaIvanRow, mqstonaIvanCol] = '*';
                            mqstonaIvanCol = mqstonaIvanCol + 1;
                        }
                    }
                }

                goto konBobQdeLi;
            konBobQdeLi:;
                command = Console.ReadLine();
                if (command == "End")
                {
                    dupkiPoMasata++;
                }
            }

            if (barnalLiEToka)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {dupkiPoMasata} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {dupkiPoMasata} hole(s) and he hit only {pipnatiJici} rod(s).");
            }
            Printirai(stena, golemina);
        }

        public static void Printirai(char[,] stena, int razmeri)
        {
            for (int r = 0; r < razmeri; r++)
            {
                for (int c = 0; c < razmeri; c++)
                {
                    Console.Write(stena[r, c]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
