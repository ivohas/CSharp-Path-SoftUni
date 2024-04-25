using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                captain = value;
            }
        }

        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }


        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.Targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsAsAString = this.Targets.Any() ? string.Join(", ", this.Targets) : "None";

            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($"*Type: {this.GetType().Name}")
                .AppendLine($"*Armor thickness: {this.ArmorThickness}")
                .AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}")
                .AppendLine($"*Speed: {this.Speed} knots")
                .AppendLine($"*Targets: {targetsAsAString}");

            return sb.ToString().Trim();
        }
    }
}
