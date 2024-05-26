namespace Wild
{
    using System;
    using System.Collections.Generic;

    public class Mouse : Mammal
    {
        private const double moseWMultiplier = 0.10;

        public Mouse(string name, double weight, string region)
            : base(name, weight, region)
        {

        }

        protected override IReadOnlyCollection<Type> FoodItLovesToEat
            => new List<Type> { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();

        protected override double Weghaitmultipleyer
            => moseWMultiplier;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.Region}, {this.Footeaten}]";
        }
    }
}