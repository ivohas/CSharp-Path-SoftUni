using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private ICollection<IRoom> rooms;
        public RoomRepository()
        {
            rooms= new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
           rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All() => (IReadOnlyCollection<IRoom>)this.rooms;
        

        public IRoom Select(string criteria)
        {
            IRoom room = rooms.FirstOrDefault(x => x.GetType().Name == criteria);
            return room;
        }
    }
}
