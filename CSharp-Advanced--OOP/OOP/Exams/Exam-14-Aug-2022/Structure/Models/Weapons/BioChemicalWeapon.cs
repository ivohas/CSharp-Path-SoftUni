using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double PRICE = 3.2;
        public BioChemicalWeapon(int destructionLevel)
            : base(destructionLevel, PRICE)
        {
        }
    }
}
