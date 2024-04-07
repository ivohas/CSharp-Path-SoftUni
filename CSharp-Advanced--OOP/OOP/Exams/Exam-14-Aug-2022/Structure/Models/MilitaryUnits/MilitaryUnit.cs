using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int INITIAL_ENDURANCE_LEVEL = 1;

        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = INITIAL_ENDURANCE_LEVEL;
        }

        private double cost;

        public double Cost
        {
            get { return cost; }
            private set { cost = value; }
        }

        private int enduranceLevel;

        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            private set { enduranceLevel = value; }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
            if (this.EnduranceLevel > 29)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
