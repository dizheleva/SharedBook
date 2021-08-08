namespace SharedBook.Models.Books
{
    using SharedBook.Data.Models.Enums;
    using System.Collections.Generic;

    public class AddBookFormModel
    {
        public string Title { get; init; }

        public string Author { get; init; }

        public Genre Genre { get; init; }

        public string Description { get; init; }

        public string Image { get; init; }

        //public int LocationId { get; set; }

        //public IEnumerable<BookLocationViewModel> Locations { get; set; } 
    }
}
