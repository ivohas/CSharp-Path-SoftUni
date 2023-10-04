using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;


namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await dbContext.Events
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(),
                }).ToListAsync();
        }

        public async Task<IEnumerable<AllEventViewModel>> GetMyEventsAsync(string userId)
        {
            return await dbContext.EventParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new AllEventViewModel
                {
                    Id = ep.EventId,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(),
                    Type = ep.Event.Type.ToString(),
                    Organiser = ep.Event.Organiser.ToString()
                }).ToArrayAsync();

        }

        public async Task<AddEventViewModel> GetNewAddEventViewModelAsync()
        {
            var types = await dbContext.Types
                .Select(c => new TypeViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            var model = new AddEventViewModel()
            {
                Types = types
            };

            return model;
        }

        public async Task AddEventAsync(AddEventViewModel model, string id)
        {
            Event e = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                Start = DateTime.Parse(model.Start),
                End = DateTime.Parse(model.End),
                TypeId = model.TypeId,
                OrganiserId = id,
            };

            await dbContext.Events.AddAsync(e);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AllEventViewModel> GetEventByIdAsync(string id)
        {
            return await dbContext
                .Events
                .Where(b => b.Id.ToString() == id)
                .Select(b => new AllEventViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Organiser = b.Organiser.ToString(),
                    Start = b.Start.ToString(),
                    Type = b.Type.ToString()

                }).FirstOrDefaultAsync();
        }

        public async Task AddToCollcetionAsync(string userId, AllEventViewModel book)
        {
            bool alreadyAdded = await dbContext.EventParticipants
                 .AnyAsync(ub => ub.HelperId == userId && ub.Event.Id == book.Id);

            var eventPar = new EventParticipant
            {
                EventId = book.Id,
                HelperId = userId
            };
            await dbContext.EventParticipants.AddAsync(eventPar);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveEventFromCollectionAsync(string userId, AllEventViewModel eventToRemove)
        {
            var eventPar = await dbContext.EventParticipants
               .FirstOrDefaultAsync(ub => ub.HelperId == userId && ub.EventId == eventToRemove.Id);
            if (eventPar != null)
            {

                dbContext.EventParticipants.Remove(eventPar);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AllEventViewModel> GetEventByIdEditAsync(string id)
        {
            var types = await dbContext.Types
                .Select(c => new TypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name

                }).ToArrayAsync();

            return await dbContext.Events
                .Where(b => b.Id.ToString() == id)
                .Select(b => new AllEventViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    CreatedOn = b.CreatedOn.ToString(),
                    Organiser = b.Organiser.ToString(),
                    Start = b.Start.ToString(),
                    Types = types.ToList(),
                    Description = b.Description,
                    End = b.End.ToString()
                }).FirstOrDefaultAsync();
        }

        public async Task EditBookAsync(AddEventViewModel model, string id)
        {
            var eventa = await dbContext.Events.Where(e=> e.Id.ToString() == id).FirstOrDefaultAsync();

            if (eventa != null)
            {
               
                eventa.Name = model.Name;
              
                eventa.Start = DateTime.Parse( model.Start);
               
                    eventa.Description = model.Description;
                eventa.End = DateTime.Parse(model.End);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
