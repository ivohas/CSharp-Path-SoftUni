using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]array=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int capacity=int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            int numOfRacks = 0;
            int sumary = 0;
            foreach (var item in array)
            {
                queue.Enqueue(item);
            }
            while (true)
            {
                if (queue.Count<1)
                {
                    break;
                }
                sumary =+queue.Peek();
                if (sumary >= capacity) 
                {
                    sumary = 0;
                    sumary += queue.Peek();
                    numOfRacks++;
                }
                queue.Dequeue();
            }
            Console.WriteLine(numOfRacks);
        }
    }
}
