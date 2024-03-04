using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => this.name;
          private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }


        public int Armour
        {
            get => this.armour;
           private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
           private set
            {
                if (weapon==null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }

        public bool IsAlive => health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            var leftArmour = Armour - points;
            if (leftArmour<0)
            {
                Armour = 0;
                var damageToDecressHealth = -leftArmour;
                if (Health>damageToDecressHealth)
                {
                    Health = Health - damageToDecressHealth;
                }
                else
                {
                    Health = 0;
                }
            }
        }
        public override string ToString()
        { 

          
            
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Name}")
               .AppendLine($"--Health: {this.Health}")
               .AppendLine($"--Armour: {this.Armour}")
                .Append($"--Weapon: {(this.Weapon != null ? this.Weapon.Name: "Unarmed" )}");
          return sb.ToString();

        }
    }
}
