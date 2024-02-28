using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Decoration : IDecoration
    {
       
       

        public Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }

        public int Comfort { get; }

        public decimal Price { get; }
    }
}
