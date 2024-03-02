using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        const int comfort = 5;
        const int price = 10;

        public Plant() 
            : base(comfort, price)
        {
        }
    }
}
