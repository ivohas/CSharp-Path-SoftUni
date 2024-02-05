using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(elements);

            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "add")
                {
                    // Push two integers, given as parameters
                    int n1 = int.Parse(cmdArgs[1]);
                    int n2 = int.Parse(cmdArgs[2]);
                    stack.Push(n1);
                    stack.Push(n2);
                }
                else if (cmdArgs[0] == "remove")
                {
                    // Pop "count" of integers
                    int count = int.Parse(cmdArgs[1]);
                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }

            int sum = stack.ToArray().Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}