using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        protected Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }
        private int comfort;

        public int Comfort
        {
            get { return comfort; }
            private set { comfort = value; }
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }


    }
}
