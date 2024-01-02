using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoftUniBazar.Contracts;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Model;
using SoftUniBazar.Models;
using System.Runtime.InteropServices;

namespace SoftUniBazar.Service
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;
        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEventAsync(AddOrEditViewModel model, string v)
        {
            var ownerId = await this.dbContext.Users.FirstOrDefaultAsync(e => e.Email == v);
            Ad ad = new Ad()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.Now,
                OwnerId = ownerId.Id
            };
            await dbContext.Ads.AddRangeAsync(ad);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(string userId, AddOrEditViewModel ad)
        {
            bool a = await dbContext.AdBuyers.Where(a => a.BuyerId == userId && a.AdId == ad.Id).AnyAsync();
            if (!a)
            {
                var adBuyer = new AdBuyer()
                {
                    AdId = ad.Id,
                    BuyerId = userId
                };

                await this.dbContext.AdBuyers.AddAsync(adBuyer);
                await dbContext.SaveChangesAsync();
            }            
        }

        public async Task<ICollection<AllAdsViewModel>> AdsInTheCartViewModel(string userId)
        {
            return await this.dbContext.AdBuyers
                .Include(ab => ab.Ad.Category)
                .Where(ab => ab.BuyerId == userId)
                .Select(ab => new AllAdsViewModel
                {
                    Id = ab.Ad.Id,
                    CreatedOn = ab.Ad.CreatedOn,
                    Name = ab.Ad.Name,
                    Description = ab.Ad.Description,
                    Owner = ab.Ad.OwnerId,
                    ImageUrl = ab.Ad.ImageUrl,
                    Category = ab.Ad.Category.Name,
                    Price = ab.Ad.Price
                }).ToArrayAsync();
        }

        public async Task<ICollection<AllAdsViewModel>> AllAdsAsync()
        {
            return await this.dbContext.Ads
                .Include(a => a.Category)
                .Include(a => a.Owner)
                .Select(a => new AllAdsViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    Category = a.Category.Name,
                    CreatedOn = a.CreatedOn,
                    Owner = a.Owner.UserName,
                    ImageUrl = a.ImageUrl,
                    Description = a.Description

                }).ToArrayAsync();
        }

        public async Task<ICollection<CategoryViewModel>> AllCategoriesAsync()
        {
            return await this.dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Name = c.Name,
                    Id = c.Id
                }).ToArrayAsync();
        }

        public async Task<bool> AlreadyAdded(string userId, AddOrEditViewModel ad)
        {
            return await dbContext.AdBuyers.Where(a => a.BuyerId == userId && a.AdId == ad.Id).AnyAsync();
        }

        public async Task EditAdAsync(AddOrEditViewModel model, int id)
        {
            var ad = await this.dbContext.Ads.Where(a => a.Id == id).FirstOrDefaultAsync();
            ad.Name = model.Name;
            ad.Description = model.Description;
            ad.CreatedOn = model.CreatedOn;
            ad.CategoryId = model.CategoryId;
            ad.Price = model.Price;

            await dbContext.SaveChangesAsync();
        }

        public async Task<AddOrEditViewModel?> GetAdByIdAsync(int id)
        {
            return await this.dbContext.
                Ads
                .Where(a => a.Id == id)
                .Select(a => new AddOrEditViewModel
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    Description = a.Description,
                    Name = a.Name,
                    Price = a.Price,
                    CategoryId = a.CategoryId

                }).FirstOrDefaultAsync();
        }

        public async Task LeaveThisEventAsync(string userId, AddOrEditViewModel ad)
        {
            var a = await this.dbContext.AdBuyers.Where(ev => ev.BuyerId == userId && ad.Id == ev.AdId).FirstOrDefaultAsync();
            this.dbContext.RemoveRange(a);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
