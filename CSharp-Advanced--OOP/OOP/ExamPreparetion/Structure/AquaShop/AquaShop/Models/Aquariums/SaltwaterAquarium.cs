namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SaltwaterAquarium:Aquarium
    {
        const int capacity = 25;
        public SaltwaterAquarium(string name):base(name,capacity)
        {
               
        }
    }
}
