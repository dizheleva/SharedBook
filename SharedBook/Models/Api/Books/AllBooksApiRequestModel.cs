namespace SharedBook.Models.Api.Books
{
    using Data.Models.Enums;
    using Models.Books;

    public class AllBooksApiRequestModel
    {
        public int BooksPerPage { get; set; } = 5;

        public int CurrentPage { get; set; } = 1;
        
        public string SearchTerm { get; init; }

        public Genre? Genre { get; init; }

        public City? Location { get; init; }

        public BookStatus? Status { get; init; }

        public BookSorting Sorting { get; init; }
    }
}
