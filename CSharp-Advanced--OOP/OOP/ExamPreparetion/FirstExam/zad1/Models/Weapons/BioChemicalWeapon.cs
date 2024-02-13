using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        const double price = 3.2;
        public BioChemicalWeapon(int destructionLevel) 
            : base(destructionLevel, price)
        {

        }
    }
}
