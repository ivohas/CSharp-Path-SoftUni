using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const int INITIAL_ARMOR_THICKNESS = 300;
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, INITIAL_ARMOR_THICKNESS)
        {
            this.SonarMode = false;
        }
        public void ToggleSonarMode()
        {
            this.SonarMode = !SonarMode;
            if (SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < INITIAL_ARMOR_THICKNESS)
            {
                this.ArmorThickness = INITIAL_ARMOR_THICKNESS;
            }
        }

        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsAsAString = this.Targets.Any() ? string.Join(", ", this.Targets) : "None";
            string sonarModeAsAString = this.SonarMode ? "ON" : "OFF";

            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($"*Type: {this.GetType().Name}")
                .AppendLine($"*Armor thickness: {this.ArmorThickness}")
                .AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}")
                .AppendLine($"*Speed: {this.Speed} knots")
                .AppendLine($"*Targets: {targetsAsAString}")
                .AppendLine($"*Sonar mode: {sonarModeAsAString}");

            return sb.ToString().Trim();
        }
    }
}
