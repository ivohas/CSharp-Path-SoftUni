namespace BookingApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Text;
    using BookingApp.Core.Contracts;
    using BookingApp.Models;
    using BookingApp.Models.Bookings;
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (this.hotels.Select(hotelName) != null)
            {
                return String.Format($"Hotel {hotelName} is already registered in our platform.");
            }

            IHotel hotel = new Hotel(hotelName, category);
            this.hotels.AddNew(hotel);
            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> orderedHotels = this.hotels.All().OrderBy(x => x.FullName).Where(x => x.Category == category).ToList();
            if (orderedHotels.Count == 0)
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            foreach (var hotel in orderedHotels)
            {
                int capacityOfAllGusts = adults + children;
                List<IRoom> rooms = hotel.Rooms.All().Where(x => x.PricePerNight != 0).OrderBy(x => x.BedCapacity).ToList();
                if (rooms.Count == 0)
                {
                    continue;
                }

                IRoom room = rooms.First();
                if (room == null)
                {
                    return OutputMessages.RoomNotAppropriate;
                }

                int bookingNumber = hotel.Bookings.All().Count + 1;
                IBooking booking = new Booking(room, duration, adults, children, bookingNumber);
                hotel.Bookings.AddNew(booking);
                return String.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
            }

            return OutputMessages.RoomNotAppropriate;
        }
        //there is a big chache of hotel report being wrong
        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine();
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine();
                    sb.Append(booking.BookingSummary());
                }
            }

            return sb.ToString();
        }
        //there is a big chance of being wrong
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room;
            if (roomTypeName == typeof(Apartment).Name)
            {
                room = hotel.Rooms.Select(roomTypeName);
            }
            else if (roomTypeName == typeof(DoubleBed).Name)
            {
                room = hotel.Rooms.Select(roomTypeName);
            }
            else if (roomTypeName == typeof(Studio).Name)
            {
                room = hotel.Rooms.Select(roomTypeName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            IRoom room;
            if (roomTypeName == typeof(Apartment).Name)
            {
                room = new Apartment();
            }
            else if (roomTypeName == typeof(DoubleBed).Name)
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == typeof(Studio).Name)
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}