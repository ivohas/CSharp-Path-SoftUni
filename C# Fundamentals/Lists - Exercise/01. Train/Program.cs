using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main()
        {
            List<int> wagons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());
            int peopleToAdd = 0;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] splitedCmdArgs = command.Split(' ');

                if (splitedCmdArgs.Length == 1)
                {
                    peopleToAdd = int.Parse(splitedCmdArgs[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + peopleToAdd <= wagonCapacity)
                        {
                            wagons[i] += peopleToAdd;
                            break;
                        }
                    }
                }
                else
                {
                    peopleToAdd = int.Parse(splitedCmdArgs[1]);

                    wagons.Add(peopleToAdd);
                }
            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
