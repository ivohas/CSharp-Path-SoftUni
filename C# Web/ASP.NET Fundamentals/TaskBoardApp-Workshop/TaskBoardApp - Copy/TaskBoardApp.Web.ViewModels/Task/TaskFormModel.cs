using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Web.ViewModels.Board;
using static TaskBoardApp.Common.EntityValidationConstants.Task;
namespace TaskBoardApp.Web.ViewModels.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght,
            ErrorMessage = "Description should be at least {2} cheracters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<BoardSelectViewModel>? AllBoards { get; set; }
    }
}
