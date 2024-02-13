using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (this.planets.Models.FirstOrDefault(x=>x.Name== planetName) == null)
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
            IWeapon weapon = null;
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            IWeapon testUnit = planet.Weapons.FirstOrDefault(w => w.GetType().Name == weapon.GetType().Name);
            if (testUnit != null)
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Army of {planetName}!");
            }
            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "AnonymousImpactUnit")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);
            return null;
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
            foreach (IPlanet planet in planets.Models)
            {
                sb
                    .AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);

            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planet1.Spend(planet1.Budget * 0.5);
                planet1.Profit(planet2.Budget * 0.5);
                planet1.Profit(planet2.MilitaryPower);
                planets.RemoveItem(planet2.Name);
                return $"{planet1.Name} destructed {planet2.Name}!";
            }
            else if (planet1.MilitaryPower < planet2.MilitaryPower)
            {
                planet2.Spend(planet2.Budget * 0.5);
                planet2.Profit(planet1.Budget * 0.5);
                planet2.Profit(planet1.MilitaryPower);
                planets.RemoveItem(planet1.Name);
                return $"{planet2.Name} destructed {planet1.Name}!";
            }
            else if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                IWeapon nuclearWeapon1 = planet1.Weapons.FirstOrDefault(w => w.GetType().Name == "NuclearWeapon");
                IWeapon nuclearWeapon2 = planet2.Weapons.FirstOrDefault(w => w.GetType().Name == "NuclearWeapon");
                if (nuclearWeapon1 != null && nuclearWeapon2 != null)
                {
                    planet1.Spend(planet1.Budget * 0.5);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (nuclearWeapon1 != null)
                {
                    planet1.Spend(planet1.Budget * 0.5);
                    planet1.Profit(planet2.Budget * 0.5);
                    planet1.Profit(planet2.MilitaryPower);
                    planets.RemoveItem(planet2.Name);
                    return $"{planet1.Name} destructed {planet2.Name}!";
                }
                else if (nuclearWeapon2 != null)
                {
                    planet2.Spend(planet2.Budget * 0.5);
                    planet2.Profit(planet1.Budget * 0.5);
                    planet2.Profit(planet1.MilitaryPower);
                    planets.RemoveItem(planet1.Name);
                    return $"{planet2.Name} destructed {planet1.Name}!";
                }
            }
            return null;
        }

        public string SpecializeForces(string planetName)
        {
            IWeapon weapon = null;
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            foreach (IMilitaryUnit unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }

            planet.AddWeapon(weapon);
            planet.Spend(1.25);
            return $"{planetName} has upgraded its forces!";
        }
    }
}
