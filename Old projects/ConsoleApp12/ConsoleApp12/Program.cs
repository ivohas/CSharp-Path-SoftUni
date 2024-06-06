using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Array.Reverse(input);
            Stack<string> stack = new Stack<string>(input);
            int sum = int.Parse(stack.Pop());
            for (int i = 0; i < input.Length / 2; i++)
            {
                string operation = stack.Pop();
                int number = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    sum += number;
                }
                else
                {
                    sum -= number;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
