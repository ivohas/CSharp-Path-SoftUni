using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favFood) :
            base(name, favFood)
        {
            this.Name = name;
            this.FavouriteFood = favFood;
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + " Meow";
        }
    }
}
