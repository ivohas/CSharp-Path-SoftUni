using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = decimal.Parse(model.Rating)
            };

             await dbContext.Books.AddAsync(book);
             await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string? userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUsersBooks
                 .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (alreadyAdded == false)
            {

                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id,
                };

                await dbContext.IdentityUsersBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await this.dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name,
                    Rating = b.Rating
                })
                .ToArrayAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.Category.Id

                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId)
        {
            return await dbContext.IdentityUsersBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new AllBookViewModel
                {
                    Id = b.BookId,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name

                }).ToListAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();

            var model = new AddBookViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task RemoveBookFromCollectionAsync(string? userId, BookViewModel bookToRemove)
        {

            var userBook = await dbContext.IdentityUsersBooks
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == bookToRemove.Id);
            if (userBook != null )
            {

                dbContext.IdentityUsersBooks.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
