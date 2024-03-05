using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private bool sonarMode = false;
       const int armourThcness = 300;
        protected Battleship(string name, double mainWeaponCaliber, double speed) :
           base(name,armourThcness,mainWeaponCaliber,speed )
        {
           
        }
        public bool SonarMode { get=>this.sonarMode; set=> this.sonarMode = value ; }
       



        public void ToggleSonarMode()
        {
            if (SonarMode==false)
            {
                SonarMode = true;
               
            }
            else
            {
                SonarMode = false;
               
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 300)
            {
               
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
                .Append($"*Sonar mode: {(this.SonarMode==true?"ON":"OFF")}");
            return base.ToString();
        }
    }
}
