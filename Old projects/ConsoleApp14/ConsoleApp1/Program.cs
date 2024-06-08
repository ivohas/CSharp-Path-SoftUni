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
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue <int> queue = new Queue<int>();
            int push = array[0];
            int pop = array[1];
            int contains = array[2];
            for (int i = 0; i < push; i++)
            {
                queue.Enqueue(list[i]);

            }
            for (int i = 0; i < pop; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(contains))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    List<int> liste = new List<int>();
                    int a = int.MaxValue;
                    foreach (var item in queue)
                    {
                        liste.Add(item);
                    }
                    for (int i = 0; i < queue.Count; i++)
                    {
                        if (a > liste[i])
                        {
                            a = liste[i];
                        }

                    }
                    Console.WriteLine(a);

                }
                else
                {
                    Console.WriteLine(0);
                }

            }
        }
    }
}
