using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rackCap = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);

            int sum = 0;
            int neededRacks = 1;
            while (stack.Count > 0)
            {
                if (sum + stack.Peek() < rackCap)
                {
                    sum += stack.Pop();
                }
                else if (sum + stack.Peek() == rackCap)
                {
                    sum += stack.Pop();
                    sum = 0;
                    if (stack.Count > 0)
                    {
                        neededRacks++;
                    }
                }
                else if (sum + stack.Peek() > rackCap)
                {
                    sum = 0;
                    sum += stack.Pop();
                    neededRacks++;
                }
            }
            Console.WriteLine(neededRacks);
        }
    }
}
