namespace PlanetWars.Models.Weapons
{
    public class SpaceMissles : Weapon
    {
        private const double Price = 8.75;

        public SpaceMissles(int destructionLevel) : base(Price, destructionLevel)
        {
        }
    }
}

