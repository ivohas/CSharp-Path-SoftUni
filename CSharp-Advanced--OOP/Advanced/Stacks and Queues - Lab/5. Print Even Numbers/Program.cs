using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            int queueSum = queue.Sum();
            int sum = 0;
            while (sum != queueSum)
            {
                sum += queue.Peek();
                if (queue.Peek() % 2 == 1)
                {
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }

            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}