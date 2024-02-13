using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class MilitaryUnit : IMilitaryUnit
    {
        private int endurace = 1;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public double Cost {
            get;
            private set;
        }

        public int EnduranceLevel {

            get => this.endurace;
           private set => this.endurace = value;
        
        }

        public void IncreaseEndurance()
        {
            if (EnduranceLevel>=20)
            {
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
            EnduranceLevel++;
        }
    }
}
