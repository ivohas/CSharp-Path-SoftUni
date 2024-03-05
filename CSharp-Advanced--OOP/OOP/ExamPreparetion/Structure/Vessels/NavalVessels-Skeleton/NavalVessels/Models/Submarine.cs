using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private bool sonarMode = false;
        const int armourThcness = 200;
        protected Submarine(string name, double mainWeaponCaliber, double speed) :
           base(name, armourThcness, mainWeaponCaliber, speed)
        {

        }
        public bool SubmergeMode { get => this.sonarMode; set => this.sonarMode = value; }
        public override void RepairVessel()
        {
            throw new NotImplementedException();
        }

        public double GetMainWeaponCaliber()
        {
            return MainWeaponCaliber;
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                SubmergeMode = true;

            }
            else
            {
                SubmergeMode = false;
              
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {Name}")
                .AppendLine($"*Type: {GetType()}")
                .AppendLine($"*Armor thickness: {ArmorThickness}")
                .AppendLine("$*Main weapon caliber: { MainWeaponCaliber}")
                .AppendLine($"*Speed: {Speed}")
                .AppendLine($"*Targets: {(this.Targets == null ? "None" : String.Join(", ", Targets))}")
                .Append($" *Submerge mode: {(this.SubmergeMode==true?"ON":"OFF")}");
            return sb.ToString();
        }
    }
}
