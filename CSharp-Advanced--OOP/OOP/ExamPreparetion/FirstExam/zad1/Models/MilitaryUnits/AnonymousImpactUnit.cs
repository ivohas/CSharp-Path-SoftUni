using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        const double cost = 30;
        public AnonymousImpactUnit() : base(cost)
        {
        }
    }
}
