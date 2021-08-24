namespace SharedBook.Services.Books
{
    using System;
    using System.Collections.Generic;
    using Data.Models.Enums;
    using Models.Books;

    public interface IBookService
    {
        BookQueryServiceModel All(
            City location = 0,
            Genre genre = 0,
            string searchTerm = null,
            BookStatus status = 0,
            BookSorting sorting = 0,
            int currentPage = 1,
            int booksPerPage = Int32.MaxValue);

        IEnumerable<BookServiceModel> Latest();

        BookDetailsServiceModel Details(int bookId);

        int Create(string title, string author, string description, string imageUrl, City location, Genre genre, BookStatus status, string userId);

        bool Edit(int id, string title, string author, string description, string imageUrl, City location, Genre genre, BookStatus status, string userId);

        IEnumerable<BookServiceModel> BooksByUser(string userId);

        bool IsOwnedByUser(int bookId, string userId);
        
        IEnumerable<string> AllTitles();
    }
}
