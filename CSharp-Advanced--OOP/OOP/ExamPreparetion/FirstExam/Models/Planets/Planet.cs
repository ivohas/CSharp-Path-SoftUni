namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }

                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get => this.militaryPower;
            private set
            {
                this.militaryPower = CaluclateMilitaryPower(value);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        private double CaluclateMilitaryPower(double militaryPower)
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

        public void AddUnit(IMilitaryUnit unit) => this.units.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => this.weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            string weaponsRow = String.Empty;
            if (this.Weapons.Count > 0)
            {
                weaponsRow = $"--Combat equipment: {String.Join(", ", this.Weapons)}";
            }
            else
            {
                weaponsRow = "No weapons";
            }

            string unitsRow = String.Empty;
            if (this.Army.Count > 0)
            {
                unitsRow = $"--Forces: {String.Join(", ", this.Army)}";
            }
            else
            {
                unitsRow = "No units";
            }
            return $"Planet: {this.Name}{Environment.NewLine}--Budget: {this.Budget} billion QUID{Environment.NewLine}--Forces: {unitsRow}{Environment.NewLine}--Combat equipment: {weaponsRow}{Environment.NewLine}--Military Power: {this.MilitaryPower}";
        }

        public void Profit(double amount) => this.Budget += amount;

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException("Budget too low!");
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}

