using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models
{
    public class Room : IRoom
    {
        private int bedcapacity;
        private double pricePerNight = 0;

        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity
        { 
        get=>this.bedcapacity;
            private set => this.bedcapacity = value;
        }

        public double PricePerNight { 
        get=>this.pricePerNight;
           private set
            {
                if (value < 0) {
                    throw new ArgumentException("Price cannot be negative!");
                }
                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
           PricePerNight= price;
        }
    }
}
