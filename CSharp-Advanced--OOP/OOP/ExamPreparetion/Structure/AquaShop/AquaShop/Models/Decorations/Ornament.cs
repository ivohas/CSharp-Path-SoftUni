using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        const int comfort = 1;
        const int price = 10;
        
        public Ornament() 
            : base(comfort, price)
        {
        }
    }
}
