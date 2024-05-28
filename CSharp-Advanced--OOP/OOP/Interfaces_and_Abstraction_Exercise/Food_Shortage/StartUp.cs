using System;
using System.Linq;

namespace Border_Control
{
    using Models;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthDate = input[3];
                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    citizens.Add(citizen);
                }
                else
                {
                    string group = input[2];
                    Rebel rebel = new Rebel(name, age, group);
                    rebels.Add(rebel);
                }
            }

            int food = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;
                if (citizens.Contains(citizens.FirstOrDefault(x => x.Name == name)))
                {
                    food += 10;
                }
                else if (rebels.Contains(rebels.FirstOrDefault(x => x.Name == name)))
                {
                    food += 5;
                }
            }
            Console.WriteLine(food);
        }
    }
}
