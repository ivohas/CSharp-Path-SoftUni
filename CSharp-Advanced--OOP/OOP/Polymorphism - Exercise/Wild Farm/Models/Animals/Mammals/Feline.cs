namespace Wild
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string region, string breed)
            : base(name, weight, region)
        {
            this.Breed = breed;
        }

        public string Breed { get; }

        public override string ToString()
        {
            return base.ToString() +
                   $"{this.Breed}, {this.Weight}, {this.Region}, {this.Footeaten}]";
        }
    }
}
