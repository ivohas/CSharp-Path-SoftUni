using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = heroes.FindByName(heroName);
            var weapon = this.weapons.FindByName(weaponName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            else
            {
                hero.AddWeapon(weapon);
                this.weapons.Remove(weapon);
                return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
            }
        }

        public string CreateHero(string type, string name, int health, int armour)
        {

            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            else
            {
                if (type == "Knight")
                {
                    Hero hero = new Knight(name, health, armour);
                    heroes.Add(hero);
                    return $"Successfully added Sir {name} to the collection.";
                }
                else if (type == "Barbarian")
                {
                    Hero hero = new Barbarian(name, health, armour);
                    heroes.Add(hero);
                    return $"Successfully added Barbarian {name} to the collection.";
                }
                else
                {
                    throw new InvalidOperationException("Invalid hero type.");
                }
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) == null)
            {
                if (type == "Mace")
                {
                    Weapon mace = new Mace(name, durability);
                    weapons.Add(mace);
                    return $"A {type.ToLower()} {name} is added to the collection.";
                }
                else if (type == "Claymore")
                {
                    Weapon claymore = new Claymore(name, durability);
                    weapons.Add(claymore);
                    return $"A {type.ToLower()} {name} is added to the collection.";
                }
                else
                {
                    throw new InvalidOperationException("Invalid weapon type.");
                }
            }
            else
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
        }

        public string HeroReport()
        {
            var sortedHeroes = this.heroes
                .Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);

            StringBuilder sb = new StringBuilder();
            foreach (var hero in sortedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon != null)
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
                else
                {
                    sb.AppendLine($"--Weapon: Unarmed");

                }

            }
            return sb.ToString();
        }

        public string StartBattle()
        {
            Map map = new Map();
            var heroesReadyForBattle = heroes
                .Models
                .Where(hero => hero.IsAlive && hero.Weapon != null)
                .ToList();
            return map.Fight(heroesReadyForBattle);
        }
    }
}
