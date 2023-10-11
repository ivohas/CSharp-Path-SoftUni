using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task AddEventAsync(AddOrEditViewModel model, string? userId, string orginezer);
        Task AddToCollectionAsync(string userId, AddOrEditViewModel eventa);
        Task EditEventAsync(AddOrEditViewModel model);
        Task<ICollection<AllEventViewModel>> GetAllEventAsync();
        Task<ICollection<TypeViewModel>> GetAllTypesAsync();
        Task<AddOrEditViewModel?> GetEventByIdAsync(int id);
        Task<DetailsViewModel> GetEventDetailsByIdAsync(int id);
        Task<ICollection<AllEventViewModel>> GetJoinedEventsByIdAsync(string userId);
        Task LeaveThisEventAsync(string userId, AddOrEditViewModel eventa);
    }
}
