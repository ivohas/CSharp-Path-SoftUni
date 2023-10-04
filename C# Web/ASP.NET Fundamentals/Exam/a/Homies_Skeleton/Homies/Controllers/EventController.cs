using Homies.Contracts;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var model = await eventService.GetAllEventsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel model = await eventService.GetNewAddEventViewModelAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await eventService.AddEventAsync(model, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return RedirectToAction(nameof(Joined));
            // redirect
        }

        public async Task<IActionResult> Joined()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await eventService.GetMyEventsAsync(userId);
            return View(model);
        }

        public async Task<IActionResult> Join(string id)
        {
            var book = await eventService.GetEventByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();
            await eventService.AddToCollcetionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(string id)
        {
            var eventa = await eventService.GetEventByIdAsync(id);
            return View(eventa);
        }

        public async Task<IActionResult> Leave(string id)
        {
            var eventToRemove = await eventService.GetEventByIdAsync(id);

            if (eventToRemove == null)
            {
                return RedirectToAction(nameof(Joined));
            }

            var userId = GetUserId();

            await eventService.RemoveEventFromCollectionAsync(userId, eventToRemove);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AllEventViewModel eventa = await eventService.GetEventByIdEditAsync(id);

            if (eventa == null)
            {
                return RedirectToAction(nameof(Joined));
            }


            return View(eventa);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Joined));
            }
            await eventService.EditBookAsync(model, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction(nameof(All));
        }
    }
}
