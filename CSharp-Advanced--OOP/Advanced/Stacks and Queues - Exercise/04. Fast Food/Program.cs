using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Console.WriteLine(queue.Max());

            int qCount = queue.Count;
            for (int i = 0; i < qCount; i++)
            {
                if (quantityFood >= queue.Peek())
                {
                    quantityFood -= queue.Peek();
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
