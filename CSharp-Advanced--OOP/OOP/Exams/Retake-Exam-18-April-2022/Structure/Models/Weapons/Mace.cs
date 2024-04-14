namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int DAMAGE = 25;
        public Mace(string name, int durability)
            : base(name, durability)
        {

        }
        public int DoDamage()
        {
            if (this.durability == 0)
            {
                return 0;
            }

            this.durability--;

            return DAMAGE;
        }
    }
}
