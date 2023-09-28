namespace Reverse_Polish_Notation
{

    using System;
    using System.Linq;
    public class Class1
    {

        static void Main(string[] args)
        {
            string? input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            string result = ReversePolishNotationConvertor(input, stack);
            Console.WriteLine((result));
            // int finalResult = CalculateReversePolishNotation(result);
            // Console.WriteLine(finalResult);
        }

        public static string ReversePolishNotationConvertor(string input, Stack<char> stack)
        {
            string result = string.Empty;

            foreach (var symbol in input)
            {
                if (symbol == '(')
                {
                    stack.Push(symbol);
                }
                else if (symbol == '*' || symbol == '/')
                {
                    stack.Push(symbol);
                }
                else if (symbol == '+' || symbol == '-')
                {
                    while (stack.Count > 0 && (stack.Peek() == '+' || stack.Peek() == '-' || stack.Peek() == '*' || stack.Peek() == '/'))
                    {
                        char currSymbol = stack.Pop();
                        result += currSymbol;
                    }
                    if (symbol != '(' || symbol != ')')
                    {
                        stack.Push(symbol);
                    }

                }
                else if (symbol == ')')
                {
                    while (stack.Peek() != '(' && stack.Count > 0)
                    {
                        char currSymbol = stack.Pop();
                        if (currSymbol != '(')
                        {
                            result += currSymbol;
                        }


                    }

                    if (stack.Peek() == '(' && stack.Count > 0)
                    {
                        stack.Pop();
                    }

                }
                else
                {
                    result += symbol;
                }
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

    }
}