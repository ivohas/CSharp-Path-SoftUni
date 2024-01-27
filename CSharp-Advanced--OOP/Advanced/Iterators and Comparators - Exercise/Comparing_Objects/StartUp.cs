using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string cmd = tokens[0];

                if (cmd == "END") break;

                string personName = tokens[0];
                int personAge = int.Parse(tokens[1]);
                string personTown = tokens[2];

                persons.Add(new Person(personName, personAge, personTown));
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            int equal = 0;
            int notEqual = 0;

            foreach (Person person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else notEqual++;
            }

            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else Console.WriteLine($"{equal} {notEqual} {persons.Count}");
        }
    }
}