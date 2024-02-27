using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        const double price = 8.75;
        public SpaceMissiles(int destructionLevel)
            : base(destructionLevel, price)
        {
        }
    }
}
