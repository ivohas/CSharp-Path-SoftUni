namespace Wild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; private set; }

        public int Footeaten { get; private set; }

        protected abstract IReadOnlyCollection<Type> FoodItLovesToEat { get; }

        protected abstract double Weghaitmultipleyer { get; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.FoodItLovesToEat.Contains(food.GetType()))
            {
                throw new FoodNotPreferredException(
                    String.Format(ExceptionMessages.FoodNotPreferred, this.GetType().Name, food.GetType().Name));
            }

            this.Footeaten += food.Q;
            this.Weight += food.Q * this.Weghaitmultipleyer;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}