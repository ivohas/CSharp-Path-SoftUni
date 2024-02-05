using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];
                if (ch == '(')
                {
                    stack.Push(i);
                }
                else if (ch == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string subExpression = expression.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
