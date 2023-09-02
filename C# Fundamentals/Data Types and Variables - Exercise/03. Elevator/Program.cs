using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleQ = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = 0;
            int counter = 0;

            if (capacity > peopleQ)
            {
                Console.WriteLine(1);
            }
            else
            {
                courses = peopleQ / capacity;
                if (peopleQ % capacity == 0)
                {
                    Console.WriteLine(courses);
                }
                else if (peopleQ % capacity != 0)
                {
                    for (int i = capacity; i <= peopleQ; i += capacity)
                    {
                        counter++;
                    }
                    Console.WriteLine(courses + 1);
                }
            }
        }
    }
}
