using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int totalCarPassed = 0;
            int n = int.Parse(Console.ReadLine());
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            string car = queue.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            totalCarPassed++;
                        }
                    }
                }
                else if (cmd == "end")
                {
                    Console.WriteLine($"{totalCarPassed} cars passed the crossroads.");
                    break;
                }
                else
                {
                    queue.Enqueue(cmd);
                }
            }
        }
    }
}
