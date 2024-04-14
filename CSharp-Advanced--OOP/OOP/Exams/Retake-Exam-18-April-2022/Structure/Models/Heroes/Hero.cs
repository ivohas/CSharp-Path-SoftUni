
namespace Heroes.Models.Heroes
{
    using Contracts;
    using System;
    using System.Text;

    public class Hero : IHero
    {
        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        private bool isAlive;
        public string Name
        {
            get { return name; }
            private set
            {
                this.name = value;
                if (string.IsNullOrWhiteSpace(this.Name))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
            }
        }
        public int Health
        {
            get { return health; }
            private set
            {
                health = value;
                if (this.Health < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                armour = value;
                if (this.Armour < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
            }
        }
        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                weapon = value;
                if (this.Weapon == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
            }
        }
        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon) => this.Weapon = weapon;

        public void TakeDamage(int points)
        {
            int ArmourStartHP = this.Armour;
            int ArmourLeft = this.Armour - points;
            int pointsLeft = points - ArmourStartHP;
            if (ArmourLeft <= 0)
            {
                this.Armour = 0;

                if (pointsLeft > 0)
                {
                    points = pointsLeft;
                    if (this.Health - points <= 0)
                    {
                        this.health = 0;
                        this.isAlive = false;
                    }
                    else
                    {
                        this.health -= pointsLeft;
                    }
                }
            }
            else
            {
                this.Armour = ArmourLeft;
            }
        }

    }
}
