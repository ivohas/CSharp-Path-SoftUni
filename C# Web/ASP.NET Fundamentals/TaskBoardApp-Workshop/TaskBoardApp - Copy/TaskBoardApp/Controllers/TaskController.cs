using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Extensions;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {

        private readonly IBoardService _boardService;
        private readonly ITaskService _taskService;
        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this._boardService = boardService;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel viewModel = new TaskFormModel()
            {
                AllBoards = await this._boardService.AllForSelectAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllBoards = await this._boardService.AllForSelectAsync();
                return this.View(model);
            }
            bool boardExist = await this._boardService.ExistByIdAsync(model.BoardId);

            if (!boardExist)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist");
                model.AllBoards = await this._boardService.AllForSelectAsync();
                return View(model);
            }

            string currentUserId = this.User.GetId();

            await this._taskService.AddAsync(currentUserId, model);

            return this.RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id) 
        {
            try
            {
                TaskDetailsViewModel viewModel = await this._taskService.GetForDetailsByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Board");
            }
        }
    }
}
