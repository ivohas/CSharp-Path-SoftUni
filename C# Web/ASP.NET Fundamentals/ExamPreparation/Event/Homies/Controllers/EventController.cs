using Homies.Contracts;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        public async Task<IActionResult> All()
        {

            ICollection<AllEventViewModel> model;

            try
            {
                model = await this.eventService.GetAllEventAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }        
        public async Task<IActionResult> Joined()
        {
            var userId = this.GetUserId();
           ICollection<AllEventViewModel> models = await this.eventService.GetJoinedEventsByIdAsync(userId);

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddOrEditViewModel();
            model.Start = DateTime.Now;
            model.End = DateTime.Now;
            try
            {
                ICollection<TypeViewModel> types = await this.eventService.GetAllTypesAsync();
                model.Types = types.ToList();
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
                return RedirectToAction(nameof(Joined));
            }
            var userId = this.GetUserId();
            var orginezer = User?.Identity?.Name ?? null;
            try
            {
                await this.eventService.AddEventAsync(model, userId, orginezer!);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Joined));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddOrEditViewModel? model = await this.eventService.GetEventByIdAsync(id);

            ICollection<TypeViewModel> types = await this.eventService.GetAllTypesAsync();
            model.Types = types.ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(All));
            }
            await this.eventService.EditEventAsync(model);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var eventa = await eventService.GetEventByIdAsync(id);

            if (eventa == null)
            {
                return RedirectToAction(nameof(All));
            }
            var userId = GetUserId();
            await this.eventService.LeaveThisEventAsync(userId, eventa);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Join(int id)
        {
            var eventa = await eventService.GetEventByIdAsync(id);

            if (eventa == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();
            await eventService.AddToCollectionAsync(userId, eventa);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Details(int id)
        {
            DetailsViewModel model = await this.eventService.GetEventDetailsByIdAsync(id);
            return this.View(model);
        }
    }
}
