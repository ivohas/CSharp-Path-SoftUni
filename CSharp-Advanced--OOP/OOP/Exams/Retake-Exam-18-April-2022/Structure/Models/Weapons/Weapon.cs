using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Weapon : IWeapon
    {
        private string name;
        protected int durability;
        private int damage;
        public Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;

                if (String.IsNullOrWhiteSpace(this.Name))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }

            }
        }

        public int Durability
        {
            get
            {
                return this.durability;
            }
            protected set
            {
                this.durability = value;
               
                if (this.Durability < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }

            }
        }

        private int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;
               
                if (this.Damage < 0)
                {
                    throw new ArgumentException("Damage cannot be below 0.");
                }

            }
        }
        public int DoDamage()
        {
            if (this.durability == 0)
            {
                return 0;
            }

            this.durability--;

            return this.damage;
        }
    }
}
