using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.army = new HashSet<IMilitaryUnit>();
            this.weapons = new HashSet<IWeapon>();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        private double budget;

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        private double militaryPower;

        public double MilitaryPower
        {
            get { return CalculateMilitaryPower(militaryPower); }
            private set { militaryPower = value; }
        }

        private readonly ICollection<IMilitaryUnit> army;
        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)this.army;

        private readonly ICollection<IWeapon> weapons;
        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)this.weapons;

        public void AddUnit(IMilitaryUnit unit) => this.army.Add(unit);

        public void AddWeapon(IWeapon weapon) => this.weapons.Add(weapon);

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string forces = this.army.Count > 0 ?
                string.Join(", ", this.army) :
                "No units";

            string equipment = this.weapons.Count > 0 ?
                string.Join(", ", this.army) :
                "No weapons";

            sb
                .AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"--Forces: {forces}")
                .AppendLine($"--Combat equipment: {equipment}")
                .AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString();
        }

        public void Profit(double amount) => this.Budget += amount;

        public void Spend(double amount)
        {
            if (this.Budget - amount < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in army)
            {
                unit.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower(double militaryPower)
        {
            militaryPower = this.Army.Sum(x => x.EnduranceLevel) + this.Weapons.Sum(x => x.DestructionLevel);

            if (this.Army.FirstOrDefault(x => x.GetType().Name == "AnonymousImpactUnit") != null)
            {
                militaryPower += militaryPower * 0.30;
            }

            if (this.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
            {
                militaryPower += militaryPower * 0.45;
            }

            return Math.Round(militaryPower, 3);
        }
    }
}