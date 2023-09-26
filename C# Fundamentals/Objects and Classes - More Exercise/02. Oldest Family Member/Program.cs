using System;
using System.Collections.Generic;

namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Family> members = new List<Family>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                Family member = new Family(name, age);
                members.Add(member);
            }

            int oldest = int.MinValue;

            string oldestPerson = string.Empty;

            foreach (Family member1 in members)
            {
                if (member1.Age > oldest)
                {
                    oldest = member1.Age;
                    oldestPerson = $"{member1.Name} {member1.Age}";
                }
            }

            Console.WriteLine(oldestPerson);
        }
    }

    class Family
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public Family(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
