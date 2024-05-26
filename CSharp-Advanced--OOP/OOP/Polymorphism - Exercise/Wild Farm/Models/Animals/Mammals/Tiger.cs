namespace Wild
{
    using System;
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        private const double tigerMultiplier = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> FoodItLovesToEat
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double Weghaitmultipleyer
            => tigerMultiplier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}