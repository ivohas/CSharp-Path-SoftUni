namespace Wild
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingS)
            : base(name, weight)
        {
            this.WingS = wingS;
        }

        public double WingS { get; }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingS}, {this.Weight}, {this.Footeaten}]";
        }
    }
}