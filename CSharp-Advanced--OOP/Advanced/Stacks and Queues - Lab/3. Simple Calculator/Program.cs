using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> operationsList = new List<string>();

            foreach (char c in input)
            {
                if (c == '+')
                {
                    operationsList.Add("add");
                }
                else if (c == '-')
                {
                    operationsList.Add("substract");
                }
            }

            Stack<int> stack = new Stack<int>(input.Split(new char[] { ' ', '+', '-' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            stack = new Stack<int>(stack);
            int sum = stack.Pop();
            for (int i = 0; i < operationsList.Count; i++)
            {
                if (operationsList[i] == "add")
                {
                    sum += stack.Pop();
                }
                else if (operationsList[i] == "substract")
                {
                    sum -= stack.Pop();
                }
            }
            Console.WriteLine(sum);
        }
    }
}
