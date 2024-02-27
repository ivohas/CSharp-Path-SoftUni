using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models
{
    public class Apartment : Room
    {
        const int bedCapacity = 6;
        public Apartment() : base(bedCapacity)
        {
        }
    }
}
