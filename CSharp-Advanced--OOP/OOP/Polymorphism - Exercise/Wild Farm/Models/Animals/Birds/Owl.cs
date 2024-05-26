namespace Wild
{
    using System;
    using System.Collections.Generic;

    public class Owl : Bird
    {
        private const double OwlMultiplier = 0.25;

        public Owl(string name, double weight, double wingS)
            : base(name, weight, wingS)
        {

        }

        protected override IReadOnlyCollection<Type> FoodItLovesToEat
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double Weghaitmultipleyer
            => OwlMultiplier;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}