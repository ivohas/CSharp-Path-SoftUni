using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Web.ViewModels.Task
{
    public class TaskDetailsViewModel : TaskViewModel
    {
        public string CreatedOn { get; set; } = null!;
        public string Board { get; set; } = null!;
    }
}
