using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnOver;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> booking;
        private Hotel()
        {
                rooms = new RoomRepository();
        }

        public Hotel(string fullName, int category)
            :this()
        {
            FullName = fullName;
            Category = category;
        }

        public string FullName { 
        get=>this.fullName;
           private set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }
                this.fullName = value;
            }
        
        }

        public int Category
        {

            get => this.category;
          private  set {
                if (value>=1&&value<=5)
                {
                    this.category = value;
                }
                else
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
            }
        }

        public double Turnover => this.TotalPaid();

        public double TotalPaid() => Math.Round(this.Bookings.All().Sum(m => m.ResidenceDuration) * this.Rooms.All().Sum(x => x.PricePerNight), 2);

        public IRepository<IRoom> Rooms { get => this.rooms; set => this.rooms = value; }
        public IRepository<IBooking> Bookings { get => this.booking; set => this.booking=value; }
    }
}
