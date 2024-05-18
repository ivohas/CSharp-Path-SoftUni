using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == "Druid")
                {
                    heroes.Add(new Druid(name));
                }
                else if (type == "Paladin")
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == "Rogue")
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    heroes.Add(new Warrior(name));
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroPower = 0;
            foreach (BaseHero hero in heroes)
            {
                heroPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (heroPower > bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else Console.WriteLine("Defeat...");
        }
    }
}
