namespace BookShop;

using Data;
using Initializer;
using System.Text;

public class StartUp
{ 
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        string cmd = Console.ReadLine();
        string result = GetBooksByAgeRestriction(db, cmd);
        Console.WriteLine(result);
    }
    // Problem 2
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
      string[] bookTitles = context.Books
            .Where(b=> b.AgeRestriction.ToString().ToLower()== command.ToLower())
            .OrderBy(b=> b.Title)
            .Select(b=> b.Title)
            .ToArray();
        return String.Join(Environment.NewLine, bookTitles);
    }

    // Problem 3
    public static string GetGoldenBooks(BookShopContext context)
    {
        var books = context.Books
            .OrderBy(b => b.BookId)
            .Where(b => b.Copies < 5000)
            .Where(b => b.EditionType == Models.Enums.EditionType.Gold)
            .Select(b => b.Title)
            .ToArray();
            

        return String.Join(Environment.NewLine, books);
    }

    // Problem 4
    public static string GetBooksByPrice(BookShopContext context)
    {
        var books = context.Books
             .Where(b => b.Price > 40)
             .OrderByDescending(b => b.Price)
             .Select(b => new { b.Title, b.Price })
             .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price.ToString("f2")}");
        }

        return sb.ToString();
    }

    // Problem 5
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        //var books = context.Books
        //    .Where(b => b.ReleaseDate != year);

        throw new NotImplementedException();
    }

    // Problem 6
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();
        var books = context.Books
            .Where(b => b.BookCategories
            .Any(bc=>categories.Contains( bc.Category.Name.ToLower())))
            .OrderBy(b=> b.Title)
            .Select(b=> b.Title)
            .ToArray();

       return string.Join(Environment.NewLine, books);
    }

    // Problem 7
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        throw new NotImplementedException();
    }

    // Problem 8

    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        throw new NotImplementedException();
    }
}


