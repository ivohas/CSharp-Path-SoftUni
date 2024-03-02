using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish:Fish
    {
        const int FishSize = 5;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = FishSize;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
