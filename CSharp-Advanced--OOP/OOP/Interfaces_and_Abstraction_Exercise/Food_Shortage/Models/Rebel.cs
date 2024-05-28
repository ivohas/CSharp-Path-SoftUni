using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control.Models
{
    using Models.Interfaces;
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { private get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
