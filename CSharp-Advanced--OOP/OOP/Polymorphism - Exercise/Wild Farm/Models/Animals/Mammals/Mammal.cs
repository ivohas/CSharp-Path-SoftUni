namespace Wild
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.Region = livingRegion;
        }

        public string Region { get; }
    }
}