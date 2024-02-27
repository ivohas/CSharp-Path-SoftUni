using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models
{
    public class DoubleBed : Room
    {
        const int bedCoount = 2;
        public DoubleBed() : base(bedCoount)
        {
        }
    }
}
