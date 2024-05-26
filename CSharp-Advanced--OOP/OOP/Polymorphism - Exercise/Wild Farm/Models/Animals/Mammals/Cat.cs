namespace Wild
{
    using System;
    using System.Collections.Generic;

    public class Cat : Feline
    {
        private const double catWMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> FoodItLovesToEat
            => new List<Type> { typeof(Vegetable), typeof(Meat) }.AsReadOnly();

        protected override double Weghaitmultipleyer
            => catWMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}