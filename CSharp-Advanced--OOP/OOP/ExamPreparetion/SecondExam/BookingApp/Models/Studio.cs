using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models
{
    public class Studio : Room
    {
        const int bedCapacity = 4;
        public Studio() : base(bedCapacity)
        {
        }
    }
}
