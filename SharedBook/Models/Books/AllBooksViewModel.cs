namespace SharedBook.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    public class AllBooksViewModel
    {
        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public IEnumerable<string> Titles { get; init; }

        public IEnumerable<string> Authors { get; init; }

        public Genre? Genre { get; init; }

        public IEnumerable<Genre?> Genres { get; init; }

        public City? Location { get; init; }

        public IEnumerable<City?> Locations { get; init; }

        public IEnumerable<string> Owners { get; init; }

        public BookStatus? Status { get; init; }

        public IEnumerable<BookStatus?> Statuses { get; init; }

        public BookSorting Sorting { get; init; }

        public IEnumerable<BookViewModel> Books { get; init; } = new List<BookViewModel>();
    }
}
