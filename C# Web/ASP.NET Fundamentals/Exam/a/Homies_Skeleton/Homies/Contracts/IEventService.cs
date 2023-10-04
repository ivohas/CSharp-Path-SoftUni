using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();
        Task<AddEventViewModel> GetNewAddEventViewModelAsync();
        Task AddEventAsync(AddEventViewModel model, string id);
        Task<IEnumerable<AllEventViewModel>> GetMyEventsAsync(string userId);
        Task<AllEventViewModel> GetEventByIdAsync(string id);
        Task AddToCollcetionAsync(string userId, AllEventViewModel book);
        Task RemoveEventFromCollectionAsync(string userId, AllEventViewModel eventToRemove);
        Task<AllEventViewModel> GetEventByIdEditAsync(string id);
        Task EditBookAsync(AddEventViewModel model, string v);
    }
}
