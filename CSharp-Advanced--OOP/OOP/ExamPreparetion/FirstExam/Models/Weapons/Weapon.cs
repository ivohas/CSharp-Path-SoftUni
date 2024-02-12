namespace PlanetWars.Models.Weapons
{
    using System;
    using Contracts;

    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        public Weapon(double price, int destructionLevel)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }

        public double Price { get; private set; }

        public int DestructionLevel
        {
            get => this.destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }

                if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }

                this.destructionLevel = value;
            }
        }
    }
}

