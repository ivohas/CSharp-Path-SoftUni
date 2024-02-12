namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double Price = 3.2;

        public BioChemicalWeapon(int destructionLevel) : base(Price, destructionLevel)
        {
        }
    }
}

