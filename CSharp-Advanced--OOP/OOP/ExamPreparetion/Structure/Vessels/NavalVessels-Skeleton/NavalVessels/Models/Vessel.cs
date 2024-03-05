using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armourThickness;
        private double mainWeaponLevel;
        private double speed;
        private ICollection<string> targets;
        private Vessel()
        {
            targets = new List<string>();
        }

        protected Vessel(string name, double armorThickness, double mainWeaponCaliber, double speed):
            this()
        {
            Name = name;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                this.name = value;
            }

        }

        public ICaptain Captain
        {
            get => this.captain;
             set
            {
                if (value==null)
                {
                    throw new NullReferenceException("Captain cannot be null.");

                }
                this.captain = value;
            }
        }
        public double ArmorThickness { get => this.armourThickness; set => this.armourThickness = value; }

        public double MainWeaponCaliber { get => this.mainWeaponLevel; private set => this.mainWeaponLevel = value; }

        public double Speed { get => this.speed; private set => this.speed = value; }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target==null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness<0)
            {
                target.ArmorThickness = 0;
                Targets.Add(target.Name);
            }
        }

        public abstract void RepairVessel();
        

        public  override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {Name}")
                .AppendLine($"*Type: {GetType()}")
                .AppendLine($"*Armor thickness: {ArmorThickness}")
                .AppendLine("$*Main weapon caliber: { MainWeaponCaliber}")
                .AppendLine($"*Speed: {Speed}")
                .Append($"*Targets: {(this.Targets == null ? "None" : String.Join(", ", Targets))}");


            return sb.ToString();
        }
    }
}
