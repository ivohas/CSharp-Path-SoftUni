namespace Wild
{
    using System;
    using System.Collections.Generic;

    public class Dog : Mammal
    {
        private const double dogWMultiplier = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        protected override IReadOnlyCollection<Type> FoodItLovesToEat
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double Weghaitmultipleyer
            => dogWMultiplier;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.Region}, {this.Footeaten}]";
        }
    }
}