namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IPlanet planet = this.planets.FindByName(planetName);

            IMilitaryUnit militaryUnit;
            if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }
            else if (unitTypeName == "AnonymosImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            if (planet.Army.Contains(militaryUnit))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            planet.AddUnit(militaryUnit);
            planet.Spend(militaryUnit.Cost);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IPlanet planet = this.planets.FindByName(planetName);

            IWeapon weapon;
            if (weaponTypeName == "SpaceMissles")
            {
                weapon = new SpaceMissles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            if (planet.Weapons.Contains(weapon))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);
            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }

            IPlanet planet = new Planet(name, budget);
            this.planets.AddItem(planet);
            return $"Successfully added Planet: {name}";
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in this.planets.Models)
            {
                sb.Append(planet.PlanetInfo());
            }

            return sb.ToString();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attacker = this.planets.FindByName(planetOne);
            IPlanet defender = this.planets.FindByName(planetTwo);

            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                attacker.Spend(attacker.Budget * 0.5);
                attacker.Profit(defender.Budget * 0.5);

                foreach (var unit in defender.Army)
                {
                    attacker.Profit(unit.Cost);
                }

                foreach (var weapon in defender.Weapons)
                {
                    attacker.Profit(weapon.Price);
                }

                this.planets.RemoveItem(defender.Name);
                return $"{attacker.Name} destructed {defender.Name}!";
            }
            else if (attacker.MilitaryPower < defender.MilitaryPower)
            {
                defender.Spend(defender.Budget * 0.5);
                defender.Profit(attacker.Budget * 0.5);

                foreach (var unit in attacker.Army)
                {
                    defender.Profit(unit.Cost);
                }

                foreach (var weapon in attacker.Weapons)
                {
                    defender.Profit(weapon.Price);
                }

                this.planets.RemoveItem(attacker.Name);
                return $"{defender.Name} destructed {attacker.Name}!";
            }
            else
            {
                IWeapon attackerNuclearWeapon = attacker.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");
                IWeapon defenderNuclearWeapon = defender.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");

                if (attackerNuclearWeapon == null && defenderNuclearWeapon != null)
                {
                    defender.Spend(defender.Budget * 0.5);
                    defender.Profit(attacker.Budget * 0.5);

                    foreach (var unit in attacker.Army)
                    {
                        defender.Profit(unit.Cost);
                    }

                    foreach (var weapon in attacker.Weapons)
                    {
                        defender.Profit(weapon.Price);
                    }

                    this.planets.RemoveItem(attacker.Name);
                    return $"{defender.Name} destructed {attacker.Name}!";
                }
                else if (attackerNuclearWeapon != null && defenderNuclearWeapon == null)
                {
                    attacker.Spend(attacker.Budget * 0.5);
                    attacker.Profit(defender.Budget * 0.5);

                    foreach (var unit in defender.Army)
                    {
                        attacker.Profit(unit.Cost);
                    }

                    foreach (var weapon in defender.Weapons)
                    {
                        attacker.Profit(weapon.Price);
                    }

                    this.planets.RemoveItem(defender.Name);
                    return $"{attacker.Name} destructed {defender.Name}!";
                }
                else
                {
                    attacker.Spend(attacker.Budget * 0.5);
                    defender.Spend(defender.Budget * 0.5);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
            }
        }

        public string SpecializeForces(string planetName)
        {
            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IPlanet planet = this.planets.FindByName(planetName);

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            return $"{planetName} has upgraded its forces!";
        }
    }
}

