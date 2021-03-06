namespace SharedBook.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    public class AllBooksViewModel
    {
        public const int BooksPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public Genre? Genre { get; init; }

        public City? Location { get; init; }

        public BookStatus? Status { get; init; }

        public BookSorting Sorting { get; init; }

        public int TotalBooks { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; } = new List<BookViewModel>();
    }
}