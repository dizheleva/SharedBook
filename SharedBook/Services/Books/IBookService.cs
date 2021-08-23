namespace SharedBook.Services.Books
{
    using System.Collections.Generic;
    using Data.Models.Enums;
    using Models.Books;

    public interface IBookService
    {
        BookQueryServiceModel All(
            City location,
            Genre genre,
            string searchTerm,
            BookStatus status,
            BookSorting sorting,
            int currentPage,
            int booksPerPage);

        BookDetailsServiceModel Details(int bookId);

        int Create(string title, string author, string description, string imageUrl, City location, Genre genre, BookStatus status, string userId);

        bool Edit(int id, string title, string author, string description, string imageUrl, City location, Genre genre, BookStatus status, string userId);

        IEnumerable<BookServiceModel> BooksByUser(string userId);

        bool IsOwnedByUser(int bookId, string userId);

        void ChangeVisility(int bookId);

        IEnumerable<string> AllTitles();
    }
}
