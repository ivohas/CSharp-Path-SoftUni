using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExpirience = 0;
        private ICollection<IVessel> vessels;
        public Captain(string fullname)
        {
            FullName = fullname;
            vessels = new List<IVessel>();
        }
        public string FullName {
            get { return fullName; }
           private  set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                this.fullName = value;            
            }
}

        public int CombatExperience { 
        get { return combatExpirience; }
           private set=>this.combatExpirience = value;
        
        }
        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel==null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            foreach (var item in vessels)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
