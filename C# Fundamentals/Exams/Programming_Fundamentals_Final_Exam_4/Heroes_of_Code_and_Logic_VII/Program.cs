using System;
using System.Collections.Generic;

namespace Problem_9___Problem_3___Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public Hero(string name, int hp, int mp)
        {
            this.Name = name;
            this.HP = hp;
            this.MP = mp;
        }

        public override string ToString()
        {
            return $"{Name}" +
                $"{Environment.NewLine}  HP: {HP}" +
                $"{Environment.NewLine}  MP: {MP}";
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Hero> heroList = new List<Hero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroArgs = Console.ReadLine().Split(' ');
                string name = heroArgs[0];
                int hp = int.Parse(heroArgs[1]);
                int mp = int.Parse(heroArgs[2]);

                Hero hero = new Hero(name, hp, mp);
                heroList.Add(hero);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string heroName = cmdArgs[1];

                if (cmdType == "CastSpell")
                {
                    int mp = int.Parse(cmdArgs[2]);
                    string spellName = cmdArgs[3];
                    CastSpell(heroList, heroName, mp, spellName);
                }
                else if (cmdType == "TakeDamage")
                {
                    int dmg = int.Parse(cmdArgs[2]);
                    string attacker = cmdArgs[3];
                    TakeDamage(heroList, heroName, dmg, attacker);
                }
                else if (cmdType == "Recharge")
                {
                    int mp = int.Parse(cmdArgs[2]);
                    Recharge(heroList, heroName, mp);
                }
                else if (cmdType == "Heal")
                {
                    int hp = int.Parse(cmdArgs[2]);
                    Heal(heroList, heroName, hp);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, heroList));


        }

        static void CastSpell(List<Hero> heroList, string name, int mp, string spell)
        {
            if (heroList.Find(x => x.Name == name).MP >= mp)
            {
                Console.WriteLine($"{name} has successfully cast {spell} and now has {heroList.Find(x => x.Name == name).MP - mp} MP!");
                heroList.Find(x => x.Name == name).MP -= mp;
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
            }
        }
        static void TakeDamage(List<Hero> heroList, string name, int dmg, string attacker)
        {
            if (heroList.Find(x => x.Name == name).HP - dmg <= 0)
            {
                Console.WriteLine($"{name} has been killed by {attacker}!");
                heroList.Remove(heroList.Find(x => x.Name == name));
                return;
            }
            Console.WriteLine($"{name} was hit for {dmg} HP by {attacker} and now has {heroList.Find(x => x.Name == name).HP - dmg} HP left!");
            heroList.Find(x => x.Name == name).HP -= dmg;

        }
        static void Recharge(List<Hero> heroList, string name, int mp)
        {
            if ((heroList.Find(x => x.Name == name).MP + mp) > 200)
            {
                Console.WriteLine($"{name} recharged for {200 - heroList.Find(x => x.Name == name).MP} MP!");
                heroList.Find(x => x.Name == name).MP = 200;
                return;
            }
            heroList.Find(x => x.Name == name).MP += mp;
            Console.WriteLine($"{name} recharged for {mp} MP!");

        }
        static void Heal(List<Hero> heroList, string name, int hp)
        {
            if ((heroList.Find(x => x.Name == name).HP + hp) > 100)
            {
                Console.WriteLine($"{name} healed for {100 - heroList.Find(x => x.Name == name).HP} HP!");
                heroList.Find(x => x.Name == name).HP = 100;
                return;
            }
            heroList.Find(x => x.Name == name).HP += hp;
            Console.WriteLine($"{name} healed for {hp} HP!");

        }


    }
}
