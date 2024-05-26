using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favFood)
        {
            this.Name = name;
            this.FavouriteFood = favFood;
        }
        public string Name { get; set; }
        public string FavouriteFood { get; set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavouriteFood}";
        }
    }
}
