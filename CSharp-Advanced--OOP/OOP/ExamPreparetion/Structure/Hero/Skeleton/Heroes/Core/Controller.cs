using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroRepository;
        private WeaponRepository weaponRepository;
        public Controller()
        {
            heroRepository = new HeroRepository();
            weaponRepository = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero= heroRepository.Models.FirstOrDefault(h => h.Name == heroName);
            if (hero==null)
            {
                throw new InvalidOperationException($"Hero { heroName} does not exist.");
            }
            IWeapon weapon = weaponRepository.Models.FirstOrDefault(weapon => weapon.Name == weaponName);
            if (weapon==null)
            {
                throw new InvalidOperationException($"Weapon { weaponName} does not exist.");
            }
            if (hero.Weapon!=null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = heroRepository.Models.FirstOrDefault(x => x.Name == name);
            if (hero!=null)
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }
            if (type=="Barbarian"||type=="Knight")
            {
                if (type== "Barbarian")
                {
                    IHero heroToAdd = new Barbarian(name, health, armour); 
                    heroRepository.Add(heroToAdd);
                    return $"Successfully added Sir {name} to the collection.";


                }
                else
                {
                    IHero heroToAdd = new Knight(name, health, armour);
                    heroRepository.Add(heroToAdd);
                    return $"Successfully added Barbarian {name} to the collection.";
                   
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
           
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = weaponRepository.Models.FirstOrDefault(x => x.Name == name);
            if (weapon != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            if (type == "Mace" || type == "Claymore")
            {
                if (type == "Mace")
                {
                    IWeapon weaopnToAdd = new Mace(name,durability);
                    weaponRepository.Add(weaopnToAdd);
                    return $"A {type } { name } is added to the collection.";


                }
                else
                {
                    IWeapon weaopnToAdd = new Claymore(name, durability);
                    weaponRepository.Add(weaopnToAdd);
                    return $"A {type} {name} is added to the collection.";

                }
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

        }

        public string HeroReport()
        {
            var sb = new StringBuilder();
            var heroes = heroRepository.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name);
            foreach (var item in heroes)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            throw new NotImplementedException();
        }
    }
}
