using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]

        public void InvalidRoomBeds()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var room = new Room(-1, 33);
            });
        }
        [Test]
        public void BedsInRoomAreOk()
        {
            Room room = new Room(2, 12);
            Assert.That(room.BedCapacity, Is.EqualTo(2));
        }
        [Test]
        public void ThePricePerNightAreBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(2, -12);
            });
        }
        [Test]
        public void ThePriceIsZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(2, 0);
            });
        }
        [Test]
        public void ThePriceIsAboveZero()
        {
            const double price = 12;
            Room room = new Room(2, price);
            Assert.That(room.PricePerNight, Is.EqualTo(price));
        }
        [Test]
        public void InvalidHotelName()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                var hotel = new Hotel(string.Empty, 4);

            });
        }
        [Test]
        public void InvalidHotelNameIsWhiteSpace()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                var hotel = new Hotel(null, 4);

            });
        }
        [Test]
        public void TheNameIsAlright()
        {
            const string name = "Kiparis";
            var hotel = new Hotel(name, 4);
            Assert.That(name, Is.EqualTo(hotel.FullName));
        }
        [Test]
        public void InvalidHotelCategoryBelowZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var hotel = new Hotel("Kiparis", 0);

            });
        }
        [Test]
        public void InvalidHotelCategoryAboveFive()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var hotel = new Hotel("Kiparis", 6);

            });
        }
        [Test]
        public void ValidHotelCategry()
        {
            var hotel = new Hotel("Kiparis", 4);
            Assert.That(hotel.Category, Is.EqualTo(4));

        }
        [Test]
        public void AddRoom()
        {
            Hotel hotel = new Hotel("Kiparis", 4);
            var room = new Room(3, 12);
            hotel.AddRoom(room);
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }
        [Test]
        public void InvalidBookOfRoomAdultsBelowZero()
        {
            Hotel hotel = new Hotel("Kiparis", 4);
            var room = new Room(3, 12);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(0, 2, 3, 1222);

            });
        }
        [Test]
        public void InvaliddBookOfRoomChilder()
        {
            Hotel hotel = new Hotel("Kiparis", 4);
            var room = new Room(3, 12);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, -2, 3, 1222);

            });
        }
        [Test]
        public void InvaliddBookOfRoomResidesDurationIsBelowZero()
        {
            Hotel hotel = new Hotel("Kiparis", 4);
            var room = new Room(3, 12);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, 1, 0, 1222);

            });
        }
        [Test]
        public void ValidBookingOfRoomIsSuccesfull()
        {
            var bookedRooms = 0;
            Hotel hotel = new Hotel("Kiparis", 4);
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            hotel.AddRoom(room2);
            hotel.AddRoom(room);
            hotel.BookRoom(2, 1, 2, 55);

            var booking = new Booking(bookedRooms += 1, room, 2);
            Assert.That(bookedRooms, Is.EqualTo(1));
            Assert.That(booking.ResidenceDuration, Is.EqualTo(2));
        }
        [Test]
        public void BookingResidatialDaysCheck()
        {

            var bookedRooms = 0;
            Hotel hotel = new Hotel("Kiparis", 4);
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.BookRoom(2, 1, 2, 55);
            var booking = new Booking(bookedRooms += 1, room, 2);
            Assert.That(booking.ResidenceDuration, Is.EqualTo(2));
        }
        [Test]
        public void turnOver()
        {
            
            Hotel hotel = new Hotel("Kiparis", 4);
            var bookedRooms = 0;
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.BookRoom(2, 1, 2, 55);
            var booking = new Booking(bookedRooms += 1, room, 2);
            double turn;
            turn=+ room2.PricePerNight * 2;
            Assert.AreEqual(44,turn);
        }
        [Test]
        public void BookinRomm()
        {
            const int adults = 2;
            Hotel hotel = new Hotel("Kiparis", 4);
            var bookedRooms = 0;
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            hotel.AddRoom(room);
            hotel.BookRoom(adults, 1, 2, 55);
            var booking = new Booking(bookedRooms += 1, room, 2);
            Assert.That(adults, Is.EqualTo(2));
        }
        [Test]
        public void CheckChilderen() {
            const int adults = 2;
            const int childer = 1;
            Hotel aa = new Hotel("Kiparis", 4);
            var bookedRooms = 0;
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            aa.AddRoom(room);
            aa.BookRoom(adults, childer, 2, 55);
            Assert.That(childer, Is.EqualTo(childer));
        }
        [Test]
        public void BookingCheck()
        {
            const int adults = 2;
            const int childer = 1;
            Hotel aa = new Hotel("Kiparis", 4);
            var bookedRooms = 0;
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            aa.AddRoom(room);
            aa.BookRoom(adults, childer, 2, 55);
            Booking book = new Booking(1,room , 2);
            Assert.That(book.Room, Is.EqualTo(room));
        }
        [Test]
        public void BookingCheckaaa() {
           
            const int adults = 2;
            const int childer = 1;
            Hotel aa = new Hotel("Kiparis", 4);
            var bookedRooms = 0;
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            aa.AddRoom(room);
            aa.BookRoom(adults, childer, 2, 55);
            Booking book = new Booking(bookedRooms+1, room, 2);
            Assert.That(book.BookingNumber, Is.EqualTo(1));
        }
        [Test]
        public void Bookingcheck()
        {
            const int adults = 2;
            const int childer = 1;
            Hotel aa = new Hotel("Kiparis", 4);
            var bookedRooms = 0;
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            aa.AddRoom(room);
            aa.BookRoom(adults, childer, 2, 55);
            Booking book = new Booking(bookedRooms + 1, room, 2);
           int a= aa.Bookings.Count;
            Assert.AreEqual(a, 1);
        }
        [Test]
        public void TurnOverCheck()
        {

            const int adults = 2;
            const int childer = 1;
            Hotel aa = new Hotel("Kiparis", 4);
            var bookedRooms = 0;
            var room = new Room(3, 12);
            var room2 = new Room(5, 22);
            aa.AddRoom(room);
            aa.BookRoom(adults, childer, 2, 55);
            Booking book = new Booking(bookedRooms + 1, room, 2);
            double turn;
            turn =+ room.PricePerNight * book.ResidenceDuration;
            Assert.That(aa.Turnover, Is.EqualTo(turn));
        }
    }
}