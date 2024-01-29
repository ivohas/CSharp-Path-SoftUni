using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            var stack = new Stack<string>();
            while (true)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = tokens[0];

                if (cmd == "END") break;
                else if (cmd == "Push")
                {
                    stack.Push(tokens.Skip(1).Select(x => x.Split(",").First()).ToArray());
                }
                else if (cmd == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                    }
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}