using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main()
        {
            List<Somebody> somebodies = new List<Somebody>();

            string command;
        BREAK:
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ').ToArray();

                string name = cmdArgs[0];
                string id = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                Somebody somebodyy = new Somebody(name, id, age);

                foreach (Somebody somebody in somebodies)
                {
                    if (somebody.ID == id)
                    {
                        somebody.Update(name, age);
                        goto BREAK;
                    }
                }

                somebodies.Add(somebodyy);

            }

            somebodies = somebodies.OrderBy(x => x.Age).ToList();

            foreach (Somebody somebody1 in somebodies)
            {
                Console.WriteLine(somebody1);
            }
        }
    }

    class Somebody
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public Somebody(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
        public void Update(string newName, int newAge)
        {
            Name = newName;
            Age = newAge;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }

    }
}
