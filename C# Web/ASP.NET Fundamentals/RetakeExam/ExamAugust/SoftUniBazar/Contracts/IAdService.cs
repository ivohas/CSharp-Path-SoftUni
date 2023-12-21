using SoftUniBazar.Models;
namespace SoftUniBazar.Contracts
{
    public interface IAdService
    {
        Task AddEventAsync(AddOrEditViewModel model, string v);
        Task AddToCollectionAsync(string userId, AddOrEditViewModel eventa);
        Task<ICollection<AllAdsViewModel>> AdsInTheCartViewModel(string userId);
        Task<ICollection<AllAdsViewModel>> AllAdsAsync();
        Task<ICollection<CategoryViewModel>> AllCategoriesAsync();
        Task<bool> AlreadyAdded(string userId, AddOrEditViewModel ad);
        Task EditAdAsync(AddOrEditViewModel model, int id);
        Task<AddOrEditViewModel> GetAdByIdAsync(int id);
        Task LeaveThisEventAsync(string userId, AddOrEditViewModel eventa);
    }
}
