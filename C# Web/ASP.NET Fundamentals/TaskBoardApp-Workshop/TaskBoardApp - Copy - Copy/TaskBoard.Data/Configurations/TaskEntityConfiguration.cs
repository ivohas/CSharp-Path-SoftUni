using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoard.Data.Configurations
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t=> t.Board)
                .WithMany(b=>b.Tasks)
                .HasForeignKey(b=>b.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(GenerateTasks());
        }

        public ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task ()
                {
                    Title="Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = "3f3836d4-ace7-4e9a-9081-0513f8a09d10",
                    BoardId = 1
                },
                new Task()
                {
                    Title="Android Client App",
                    Description = "Create Android client app for the TaskBorad RestFul API",
                    CreatedOn = DateTime.UtcNow.AddDays(-5),
                    OwnerId = "c7626073-c7b3-4049-9e09-99a5097998d8",
                    BoardId = 1
                },
                new Task()
                {
                    Title="Desktop Client App",
                    Description = "Create Desktop client app for the TaskBorad RestFul API",
                    CreatedOn = DateTime.UtcNow.AddDays(-1),
                    OwnerId = "c7626073-c7b3-4049-9e09-99a5097998d8",
                    BoardId = 2
                },
                new Task()
                {
                    Title="Create Task",
                    Description = "Implement [Create Task] page for adding new Task",
                    CreatedOn = DateTime.UtcNow.AddYears(-1),
                    OwnerId = "3f3836d4-ace7-4e9a-9081-0513f8a09d10",
                    BoardId = 3
                }
            };
            return tasks;
        }
    }
}
