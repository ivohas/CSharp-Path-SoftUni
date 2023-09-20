using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    int appendNumber = int.Parse(cmdArgs[1]);
                    numbers.Add(appendNumber);
                }
                else if (cmdType == "Insert")
                {
                    int insertNumber = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);

                    if (!IsIndexValid(numbers, index))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, insertNumber);
                }
                else if (cmdType == "Remove")
                {
                    int removeIndex = int.Parse(cmdArgs[1]);

                    if (!IsIndexValid(numbers, removeIndex))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(removeIndex);

                }
                else if (cmdType == "Shift")
                {
                    string direction = cmdArgs[1];
                    int count = int.Parse(cmdArgs[2]);
                    int realPerformCount = count % numbers.Count;

                    if (direction == "left")
                    {
                        ShiftLeft(numbers, realPerformCount);
                    }
                    else if (direction == "right")
                    {
                        ShiftRight(numbers, realPerformCount);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", numbers));

        }

        static void ShiftRight(List<int> numbers, int count)
        {
            int realPerformCount = count % numbers.Count;

            for (int cnt = 1; cnt <= realPerformCount; cnt++)
            {
                int lastElement = numbers.Last();
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastElement);
            }
        }
        static void ShiftLeft(List<int> numbers, int count)
        {
            int realPerformCount = count % numbers.Count;

            for (int cnt = 1; cnt <= realPerformCount; cnt++)
            {
                int firstElement = numbers.First();
                numbers.RemoveAt(0);
                numbers.Add(firstElement);
            }
        }
        static bool IsIndexValid(List<int> numbers, int index)
        {
            return index >= 0 && index < numbers.Count;
        }
    }
}
