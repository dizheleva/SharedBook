namespace SharedBook.Models.Api.Books
{
    using System.Collections.Generic;
    using Services.Books;

    public class AllBooksApiResponseModel
    {
        public int CurrentPage { get; init; }

        public int BooksPerPage { get; init; }

        public int TotalBooks { get; init; }

        public IEnumerable<BookServiceModel> Books { get; init; } = new List<BookServiceModel>();
    }
}
