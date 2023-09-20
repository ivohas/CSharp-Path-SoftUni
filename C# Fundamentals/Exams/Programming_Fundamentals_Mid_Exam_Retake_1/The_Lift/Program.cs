using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleLeft = int.Parse(Console.ReadLine());
            List<int> wagons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            const int wagonsCapacity = 4;
            int filledWagonsCount = 0;

            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] <= wagonsCapacity)
                {
                    if (peopleLeft >= wagonsCapacity - wagons[i])
                    {
                        peopleLeft -= (wagonsCapacity - wagons[i]);
                        wagons[i] += (wagonsCapacity - wagons[i]);

                    }
                    else
                    {
                        wagons[i] += peopleLeft;
                        peopleLeft = 0;
                        continue;
                    }
                }

                if (wagons[1] == wagonsCapacity)
                {
                    filledWagonsCount++;
                }
            }

            if (peopleLeft == 0 && filledWagonsCount < wagons.Count)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(' ', wagons));
            }
            else if (peopleLeft > 0 && filledWagonsCount < wagons.Count)
            {
                Console.WriteLine($"There isn't enough space! {peopleLeft} people in a queue!");
                Console.WriteLine(String.Join(' ', wagons));
            }
            else if (peopleLeft == 0 && filledWagonsCount == wagons.Count)
            {
                Console.WriteLine(String.Join(' ', wagons));
            }
        }
    }
}
