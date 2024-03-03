using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private ICollection<IBooking> bookings;
        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => (IReadOnlyCollection<IBooking>)this.bookings;
       

        public IBooking Select(string criteria)
        {
            var book = bookings.FirstOrDefault(x => x.BookingNumber == int.Parse(criteria));
            return book;
        }
    }
}
