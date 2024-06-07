using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int carPassed = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "green")
                {
                    if (queue.Count > 0)
                    {
                        if (queue.Count < n)
                        {
                            for (int i = 0; i < queue.Count+1; i++)
                            {
                                string carThatPassed = queue.Peek();
                                queue.Dequeue();
                                carPassed++;
                                Console.WriteLine($"{carThatPassed} passed!");

                            }

                        }
                        else
                        {
                            for (int i = 0; i < n; i++)
                            {

                                string carThatPassed = queue.Peek();
                                queue.Dequeue();
                                carPassed++;
                                Console.WriteLine($"{carThatPassed} passed!");

                            }
                        }

                    }

                }
                else if (command == "end")
                {
                    Console.WriteLine($"{carPassed} cars passed the crossroads.");
                    break;
                }
                else
                {
                    queue.Enqueue(command);
                }



            }
        }
    }
}
