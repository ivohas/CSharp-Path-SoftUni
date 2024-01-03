using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Interfaces
{
    public interface ITaskService
    {
        Task AddAsync(string userId, TaskFormModel viewModel);
    }
}
