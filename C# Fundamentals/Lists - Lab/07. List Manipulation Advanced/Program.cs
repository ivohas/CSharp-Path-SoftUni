using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                switch (cmdType)
                {
                    case "Add":
                        int numberToAdd = int.Parse(cmdArgs[1]);
                        numbers.Add(numberToAdd);
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(cmdArgs[1]);
                        numbers.Remove(numberToRemove);
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(cmdArgs[1]);
                        numbers.RemoveAt(indexToRemove);
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(cmdArgs[1]);
                        int indexToInsert = int.Parse(cmdArgs[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        Console.WriteLine(String.Join(" ", numbers));
                        break;

                    case "Contains":
                        int certainNumber = int.Parse(cmdArgs[1]);
                        ContainsACertainNumber(numbers, certainNumber);
                        break;
                    default:
                        break;
                    case "PrintEven":
                        PrintEven(numbers);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;
                    case "GetSum":
                        GetSum(numbers);
                        break;
                    case "Filter":
                        string condition = cmdArgs[1];
                        int index = int.Parse(cmdArgs[2]);
                        switch (condition)
                        {
                            case "<":
                                Console.WriteLine(String.Join(" ", numbers.FindAll(x => x < index)));
                                break;
                            case ">":
                                Console.WriteLine(String.Join(" ", numbers.FindAll(x => x > index)));
                                break;
                            case ">=":
                                Console.WriteLine(String.Join(" ", numbers.FindAll(x => x >= index)));
                                break;
                            case "<=":
                                Console.WriteLine(String.Join(" ", numbers.FindAll(x => x <= index)));
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        static void ContainsACertainNumber(List<double> numbers, double certainNumber)
        {
            if (numbers.Contains(certainNumber))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEven(List<double> numbers)
        {
            List<double> evenNumbers = numbers.ToList();
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    evenNumbers.Remove(number);
                }
            }

            Console.WriteLine(String.Join(" ", evenNumbers));
        }

        static void PrintOdd(List<double> numbers)
        {
            List<double> oddNumber = numbers.ToList();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    oddNumber.Remove(number);
                }
            }

            Console.WriteLine(String.Join(" ", oddNumber));
        }

        static void GetSum(List<double> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }

    }
}
