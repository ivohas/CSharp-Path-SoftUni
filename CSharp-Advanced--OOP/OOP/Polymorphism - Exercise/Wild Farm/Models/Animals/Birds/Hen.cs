namespace Wild
{
    using System;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        private const double henweghitmultiplayer = 0.35;

        public Hen(string name, double weight, double wingS)
            : base(name, weight, wingS)
        {

        }

        protected override IReadOnlyCollection<Type> FoodItLovesToEat
            => new List<Type>
                    { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) }
                .AsReadOnly();

        protected override double Weghaitmultipleyer
            => henweghitmultiplayer;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}