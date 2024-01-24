using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                Predicate<string> predicate = GetPredicate(command);

                if (command.StartsWith("Double"))
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        string person = people[i];
                        if (predicate(person))
                        {
                            people.Insert(i + 1, person);
                            i++;
                        }
                    }
                }
                else if (command.StartsWith("Remove"))
                    people.RemoveAll(predicate);

                command = Console.ReadLine();
            }

            if (people.Count == 0)
                Console.WriteLine("Nobody is going to the party!");
            else
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
        }

        private static Predicate<string> GetPredicate(string command)
        {
            string command2 = command.Split()[1];
            string arg = command.Split()[2];

            Predicate<string> predicate = null;
            if (command2 == "StartsWith")
                predicate = name => name.StartsWith(arg);
            else if (command2 == "EndsWith")
                predicate = name => name.EndsWith(arg);
            else if (command2 == "Length")
                predicate = name => name.Length == int.Parse(arg);
            return predicate;
        }
    }
}