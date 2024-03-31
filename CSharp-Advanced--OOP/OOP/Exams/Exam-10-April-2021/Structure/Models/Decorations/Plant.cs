namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int COMFORT = 5;
        private const decimal PRICE = 10m;
        public Plant()
            : base(COMFORT, PRICE)
        {

        }
    }
}
