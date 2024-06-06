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
            Queue<string> paid = new Queue<string>();
            string name = Console.ReadLine(); int counter = 0;

            while (name != "End")
            {
                counter++;
                paid.Enqueue(name);
                if (name == "Paid")
                {

                    for (int i = 1; i < counter; i++)
                    {
                        
                        Console.WriteLine(paid.Dequeue()); 

                    }

                    
                    counter = 0;
                }


                name = Console.ReadLine();
            }
           
            Console.WriteLine($"{counter} people remaining.");
        }
    }
}
