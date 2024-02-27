using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residentDuratiom;
        private int adults;
        private int child;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room {
            get => this.room;
                private set=>this.room = value;
        }

        public int ResidenceDuration { 
        get=> this.residentDuratiom;
            private set {
                if (value<1)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                this.ResidenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => this.adults;
            private set {
                if (value<1)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
            this.adults = value;
            }
        }
        public int ChildrenCount {
            get => this.child;
            private set {
                if (value<0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
            this.child= value;
            }
        
        }

        public int BookingNumber
        {
            get => this.BookingNumber;
            private set => this.BookingNumber = value;
        
        }

        public string BookingSummary()
        {
            var TotalPaid = Math.Round(ResidenceDuration * Room.PricePerNight, 2);

            var sb= new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Room type: {Room.GetType().Name}")
                .AppendLine($"Adults: {AdultsCount}")
                .AppendLine($" Children: {ChildrenCount}")
                .Append($"Total amount paid: {TotalPaid:F2}$");
            return sb.ToString(); 
        }
    }
}
