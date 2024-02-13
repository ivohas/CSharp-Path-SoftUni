using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        const double price = 15;
        public NuclearWeapon(int destructionLevel) 
            : base(destructionLevel, price)
        {
        }
    }
}
