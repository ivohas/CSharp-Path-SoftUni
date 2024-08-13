using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> token = new List<string>();
            string input = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Finish")
            {
                token = command.Split(' ').ToList();
                if (token[0] == "Replace")
                {
                    string sub = token[1];
                    string newSub = token[2];
                    if (input.Contains(sub))
                    {
                        input = input.Replace(sub, newSub);
                        Console.WriteLine(input);
                    }

                }
                else if (token[0] == "Cut")
                {
                    int startInd = int.Parse(token[1]);
                    int endInd = int.Parse(token[2]);
                    if (startInd >= 0 && startInd <= input.Length && endInd >= 0 && endInd < input.Length)
                    {
                        int count = endInd - startInd + 1;
                        input = input.Remove(startInd, count);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }

                }
                else if (token[0] == "Make")
                {
                    if (token[1] == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    else
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }
                else if (token[0] == "Check")
                {
                    string check = token[1];
                    if (input.Contains(check))
                    {
                        Console.WriteLine($"Message contains {check}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {check}");
                    }
                }
                else if (token[0]=="Sum")
                {
                    int startIndex = int.Parse(token[1]);
                    int endIndex = int.Parse(token[2]);
                    if (startIndex < 0 || endIndex > input.Length - 1)
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    else
                    {
                        int asciiSum = 0;
                        string substring = input.Substring(startIndex, endIndex - startIndex + 1);
                        foreach (var symbol in substring)
                        {
                            asciiSum += (int)symbol;
                        }
                        Console.WriteLine(asciiSum);
                    }


                }




                command = Console.ReadLine();
            }
        }
    }
}
