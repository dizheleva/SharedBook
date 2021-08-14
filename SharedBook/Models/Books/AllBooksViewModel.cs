namespace SharedBook.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    public class AllBooksViewModel
    {
        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public Genre? Genre { get; init; }

        public City? Location { get; init; }
        
        public BookStatus? Status { get; init; }

        public BookSorting Sorting { get; init; }

        public IEnumerable<BookViewModel> Books { get; set; } = new List<BookViewModel>();
    }
}
