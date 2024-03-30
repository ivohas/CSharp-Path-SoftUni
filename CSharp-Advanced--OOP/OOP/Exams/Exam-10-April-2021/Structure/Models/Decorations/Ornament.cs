namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int COMFORT = 1;
        private const decimal PRICE = 5m;
        public Ornament()
            : base(COMFORT, PRICE)
        {

        }
    }
}
