using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, List<int>> add = list => list.Select(n => n += 1).ToList();

            Func<List<int>, List<int>> multiply = list => list.Select(n => n *= 2).ToList();

            Func<List<int>, List<int>> subtract = list => list.Select(n => n -= 1).ToList();

            Action<List<int>> print = list => Console.WriteLine(String.Join(" ", list));

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }


                command = Console.ReadLine();
            }
        }
    }
}
