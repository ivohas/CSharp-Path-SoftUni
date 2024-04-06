using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double PRICE = 15;
        public NuclearWeapon(int destructionLevel)
            : base(destructionLevel, PRICE)
        {
        }
    }
}
