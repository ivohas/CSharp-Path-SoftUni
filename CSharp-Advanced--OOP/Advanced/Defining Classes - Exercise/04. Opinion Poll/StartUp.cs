using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 1; i <= n; i++)
            {
                string data = Console.ReadLine();
                string name = data.Split()[0];
                int age = int.Parse(data.Split()[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            foreach (var member in family.familyMembers.OrderBy(x => x.Name))
            {
                if (member.Age > 30)
                {
                    Console.WriteLine($"{member.Name} - {member.Age}");
                }
            }

        }
    }
}
