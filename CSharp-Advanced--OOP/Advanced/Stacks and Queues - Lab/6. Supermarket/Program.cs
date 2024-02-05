using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> q = new Queue<string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, q));
                    q.Clear();
                }
                else if (name == "End")
                {
                    Console.WriteLine($"{q.Count} people remaining.");
                    break;
                }
                else q.Enqueue(name);
            }
        }
    }
}
