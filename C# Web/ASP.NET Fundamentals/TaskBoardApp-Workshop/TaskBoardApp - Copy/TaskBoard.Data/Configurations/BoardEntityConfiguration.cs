using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Data.Models;

namespace TaskBoard.Data.Configurations
{
    internal class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = this.GenereBoards();

            builder
                .HasData(boards);
        }
        private ICollection<Board> GenereBoards()
        {
            ICollection<Board> boards = new HashSet<Board>();

            Board currentBoard;
            currentBoard = new Board()
            {
                Name = "Open",
                Id = 1
            };
            boards.Add(currentBoard);
            currentBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            boards.Add(currentBoard);
            currentBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            boards.Add(currentBoard);

            return boards;
        }
    }
}
