using Homies.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SoftUniBazar.Contracts;
using SoftUniBazar.Models;
using System.Runtime.CompilerServices;

namespace SoftUniBazar.Controllers
{
    public class AdController : BaseController
    {
        private readonly IAdService adService;
        public AdController(IAdService adService)
        {
            this.adService = adService;
        }
        public async Task<IActionResult> All()
        {
            ICollection<AllAdsViewModel> viewModel;
            try
            {
                viewModel = await this.adService.AllAdsAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return View(viewModel);
        }
        public async Task<IActionResult> AddToCart(int id)
        {

            var ad = await adService.GetAdByIdAsync(id);

            if (ad == null)
            {
                throw new ArgumentException();
            }

            var userId = GetUserId();
            try
            {
                bool alreadyAdded = await this.adService.AlreadyAdded(userId, ad);
                if (alreadyAdded)
                {
                    return RedirectToAction(nameof(All));
                }
                await adService.AddToCollectionAsync(userId, ad);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var ad = await this.adService.GetAdByIdAsync(id);

            if (ad == null)
            {
                throw new Exception();
            }
            var userId = GetUserId();
            try
            {
                await this.adService.LeaveThisEventAsync(userId, ad);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(All));
        }
        public async Task<IActionResult> Cart()
        {
            ICollection<AllAdsViewModel> models;
            var userId = this.GetUserId();
            try
            {
                models = await this.adService.AdsInTheCartViewModel(userId);
            }
            catch (Exception)
            {

                throw;
            }

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddOrEditViewModel model;
            try
            {
                ICollection<CategoryViewModel> categoryViewModels = await this.adService.AllCategoriesAsync();
                model = new AddOrEditViewModel();
                model.Categories = categoryViewModels.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var orginezer = User?.Identity?.Name ?? null;
            try
            {
                await this.adService.AddEventAsync(model, orginezer!);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddOrEditViewModel model;
            try
            {
                model = await this.adService.GetAdByIdAsync(id);

                ICollection<CategoryViewModel> categoryViewModels = await this.adService.AllCategoriesAsync();

                model.Categories = categoryViewModels.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddOrEditViewModel ad)
        {
           
            if (!ModelState.IsValid)
            {
                return View(ad);
            }

            await this.adService.EditAdAsync(ad, id);

            return RedirectToAction("All", "Ad");
        }

    }
}
