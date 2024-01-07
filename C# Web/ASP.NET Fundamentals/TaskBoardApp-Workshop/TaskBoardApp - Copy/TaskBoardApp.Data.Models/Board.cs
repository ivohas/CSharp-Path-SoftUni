using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidationConstants.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
