namespace SharedBook.Services.Books
{
    using System.Collections.Generic;

    public class BookQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int BooksPerPage { get; init; }

        public int TotalBooks { get; init; }

        public IEnumerable<BookDetailsServiceModel> Books { get; set; } = new List<BookDetailsServiceModel>();
    }
}
