using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId);
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task AddBookToCollectionAsync(string? userId, BookViewModel book);
        Task RemoveBookFromCollectionAsync(string? userId, BookViewModel bookToRemove);
        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task AddBookAsync(AddBookViewModel model);
    }
}
