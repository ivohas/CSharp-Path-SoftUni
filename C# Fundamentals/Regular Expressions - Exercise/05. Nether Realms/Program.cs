using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Demon
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();

            string[] demonsArrFormat = Regex.Split(Console.ReadLine(), @"(\,{1}\s)");

            for (int i = 0; i < demonsArrFormat.Length; i++)
            {
                demonsArrFormat[i] = demonsArrFormat[i].Trim();
                Demon demon = new Demon(demonsArrFormat[i], 0, 0);
                demons.Add(demon);
            }

            Regex healthPattern = new Regex(@"([A-Za-z])");
            Regex damagePattern = new Regex(@"([\-]?\d+(\.\d+)?)");
            Regex mathOperationPattern = new Regex(@"[\*]|[\/]");

            Regex demonNameValidator = new Regex(@"(\s|\,)");

            foreach (Demon demon in demons.OrderBy(demon => demon.Name))
            {
                Match valdatorMatch = demonNameValidator.Match(demon.Name);
                if (valdatorMatch.Success)
                {
                    continue;
                }

                int currDemonHealth = 0;

                Match[] healthValues = healthPattern.Matches(demon.Name).ToArray();
                foreach (Match healthValue in healthValues)
                {
                    currDemonHealth += char.Parse(healthValue.Value);
                }

                demon.Health += currDemonHealth;

                double currDemonDamage = 0;

                Match[] damageValues = damagePattern.Matches(demon.Name).ToArray();
                foreach (Match damageValue in damageValues)
                {
                    currDemonDamage += double.Parse(damageValue.Value);
                }

                demon.Damage += currDemonDamage;

                Match[] mathOperations = mathOperationPattern.Matches(demon.Name).ToArray();
                foreach (Match mathOperation in mathOperations)
                {
                    if (mathOperation.Value == "*")
                    {
                        demon.Damage *= 2;
                    }
                    else if (mathOperation.Value == "/")
                    {
                        demon.Damage /= 2;
                    }
                }

                Console.WriteLine(demon);
            }
        }
    }
}
