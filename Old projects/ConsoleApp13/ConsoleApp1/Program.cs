using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();  
            foreach (var item in array)
            { 
                queue.Enqueue(item);
            }
            for (int i = 0; i <=queue.Count-1; i++)
            {
                for (int a = 0; a <n--; a++)
                {
                    string name = queue.Peek();
                    queue.Dequeue();
                    queue.Enqueue(name);
                }
                string nameToRemove=queue.Peek();
                queue.Dequeue();
                Console.WriteLine($"Removed {nameToRemove}");
            }
            string last = queue.Peek();
            Console.WriteLine($"Last is {last}");
        }
    }
}
