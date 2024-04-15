using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const int INITIAL_ARMOR_THICKNESS = 200;
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, INITIAL_ARMOR_THICKNESS)
        {
            this.SubmergeMode = false;
        }
        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < INITIAL_ARMOR_THICKNESS)
            {
                this.ArmorThickness = INITIAL_ARMOR_THICKNESS;
            }
        }

        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsAsAString = this.Targets.Any() ? string.Join(", ", this.Targets) : "None";
            string submergeModeAsAString = this.SubmergeMode ? "ON" : "OFF";

            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Armor thickness: {this.ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}")
                .AppendLine($" *Speed: {this.Speed} knots")
                .AppendLine($" *Targets: {targetsAsAString}")
                .AppendLine($" *Submerge mode: {submergeModeAsAString}");

            return sb.ToString().Trim();
        }
    }
}
