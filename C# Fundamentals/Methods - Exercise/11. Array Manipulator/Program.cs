using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(' ');

                string cmdType = cmdArgs[0];
                if (cmdType == "exchange")
                {
                    int exchangeIndex = int.Parse(cmdArgs[1]);

                    if (exchangeIndex < 0 || exchangeIndex >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers = Exchange(numbers, exchangeIndex);
                }
                else if (cmdType == "max" || cmdType == "min")
                {
                    string oddOrEven = cmdArgs[1];

                    int index;
                    if (cmdType == "max")
                    {
                        index = MaxElementOfTypeIndex(numbers, oddOrEven);
                    }
                    else
                    {
                        index = MinElementOfTypeIndex(numbers, oddOrEven);
                    }
                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (cmdType == "first" || cmdType == "first")
                {
                    int count = int.Parse(cmdArgs[1]);
                    string oddOrEven = cmdArgs[2];

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (cmdType == "first")
                    {
                        PrintFirstElementsOfType(numbers, count, oddOrEven);
                    }
                    else
                    {
                        PrintLastElementsOfType(numbers, count, oddOrEven);
                    }
                }
            }

            Console.WriteLine(ArrayToString(numbers, numbers.Length));

        }

        static int[] Exchange(int[] numbers, int exchangeIndex)
        {
            int[] exchangedNumbers = new int[numbers.Length];
            int exchangedNumbersIndex = 0;

            for (int i = exchangeIndex + 1; i < numbers.Length; i++)
            {
                exchangedNumbers[exchangedNumbersIndex] = numbers[i];
                exchangedNumbersIndex++;
            }

            for (int i = 0; i <= exchangeIndex; i++)
            {
                exchangedNumbers[exchangedNumbersIndex] = numbers[i];
                exchangedNumbersIndex++;
            }

            return exchangedNumbers;
        }

        static int MaxElementOfTypeIndex(int[] numbers, string oddOrEven)
        {
            int index = -1;
            int maxValue = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && currNum >= maxValue)
                    {
                        maxValue = currNum;
                        index = i;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && currNum >= maxValue)
                    {
                        maxValue = currNum;
                        index = i;
                    }
                }
            }

            return index;
        }

        static int MinElementOfTypeIndex(int[] numbers, string oddOrEven)
        {
            int index = -1;
            int minValue = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && currNum <= minValue)
                    {
                        minValue = currNum;
                        index = i;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && currNum <= minValue)
                    {
                        minValue = currNum;
                        index = i;
                    }
                }
            }

            return index;
        }

        static void PrintFirstElementsOfType(int[] numbers, int count, string oddOrEven)
        {
            int[] firstElements = new int[count];
            int firstElementsIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && firstElementsIndex < count)
                    {
                        firstElements[firstElementsIndex] = currNum;
                        firstElementsIndex++;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && firstElementsIndex < count)
                    {
                        firstElements[firstElementsIndex] = currNum;
                        firstElementsIndex++;
                    }
                }
            }

            Console.WriteLine(ArrayToString(firstElements, firstElementsIndex));

        }

        static void PrintLastElementsOfType(int[] numbers, int count, string oddOrEven)
        {
            int[] lastElements = new int[count];
            int lastElementsIndex = 0;

            for (int i = numbers.Length; i > 0; i--)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && lastElementsIndex < count)
                    {
                        lastElements[lastElementsIndex] = currNum;
                        lastElementsIndex++;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && lastElementsIndex < count)
                    {
                        lastElements[lastElementsIndex] = currNum;
                        lastElementsIndex++;
                    }
                }
            }

            int[] reversedArray = new int[count];
            int reversedArrayIndex = 0;
            for (int i = lastElementsIndex; i > 0; i--)
            {
                reversedArray[reversedArrayIndex++] = lastElements[i];
                reversedArrayIndex++;
            }

            Console.WriteLine(ArrayToString(reversedArray, reversedArrayIndex));

        }

        static string ArrayToString(int[] arr, int elemntsCount)
        {
            string output = string.Empty;
            output += "[";

            for (int i = 0; i < elemntsCount; i++)
            {
                if (i == elemntsCount - 1)
                {
                    output += $"{arr[i]}";
                }
                else
                {
                    output += $"{arr[i]}, ";
                }
            }
            output += "]";

            return output;
        }
    }
}
