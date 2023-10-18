using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Service
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEventAsync(AddOrEditViewModel model, string? userId, string orginezer)
        {
            var orginezId = await this.dbContext.Users.FirstOrDefaultAsync(e => e.Email == orginezer);
            var newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = orginezId.Id,
                CreatedOn = DateTime.Now,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId, // Replace with the actual TypeId                              
            };

            await this.dbContext.Events.AddAsync(newEvent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(string userId, AddOrEditViewModel eventa)
        {
            var a = new EventParticipant()
            {
                EventId = eventa.Id,
                HelperId = userId
            };

            await this.dbContext.EventsParticipants.AddAsync(a);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditEventAsync(AddOrEditViewModel model)
        {
            var a = await this.dbContext.Events.FirstOrDefaultAsync(a => a.Id == model.Id);
            a.Name = model.Name;
            a.Description = model.Description;
            a.End = model.End;
            a.Start = a.Start;
            a.TypeId = model.TypeId;
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AllEventViewModel>> GetAllEventAsync()
        {
            return await this.dbContext.Events
                 .Include(e => e.Type)
                 .Include(e => e.Organiser)
                 .Select(e => new AllEventViewModel
                 {
                     Id = e.Id,
                     Name = e.Name,
                     Description = e.Description,
                     Type = e.Type.Name,
                     Start = e.Start,
                     CreatedOn = e.CreatedOn,
                     End = e.End,
                     Organiser = e.Organiser.UserName

                 }).ToArrayAsync();
        }

        public async Task<ICollection<TypeViewModel>> GetAllTypesAsync()
        {
            return await this.dbContext
                .Types
                .Select(t => new TypeViewModel
                {

                    Id = t.Id,
                    Name = t.Name,
                }).ToArrayAsync();
        }

        public async Task<AddOrEditViewModel?> GetEventByIdAsync(int id)
        {
            return await dbContext.Events.Where(a => a.Id == id).
            Select(a => new AddOrEditViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Start = a.Start,
                End = a.End,
                TypeId = a.TypeId

            }).FirstOrDefaultAsync()!;
        }

        public async Task<DetailsViewModel?> GetEventDetailsByIdAsync(int id)
        {
            return await this.dbContext.Events.Include(e=> e.Organiser).Include(e=> e.Type).Where(a => a.Id == id)
                .Select(e => new DetailsViewModel
                {
                    Id = e.Id,
                    CreatedOn = e.CreatedOn,
                    Description = e.Description,
                    End = e.End,
                    Start = e.Start,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                    
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<AllEventViewModel>> GetJoinedEventsByIdAsync(string userId)
        {
            return await dbContext.EventsParticipants
                    .Where(ep => ep.HelperId == userId)
                        .Select(ep => new AllEventViewModel
                        {
                            Id = ep.EventId,
                            Name = ep.Event.Name,
                            Start = ep.Event.Start,
                            End = ep.Event.End,
                            Organiser = ep.Event.Organiser.ToString()
                        }).ToArrayAsync();
        }

        public async Task LeaveThisEventAsync(string userId, AddOrEditViewModel eventa)
        {
            var a = await this.dbContext.EventsParticipants.Where(ev => ev.HelperId == userId && eventa.Id == ev.EventId).FirstOrDefaultAsync();
            this.dbContext.RemoveRange(a);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
