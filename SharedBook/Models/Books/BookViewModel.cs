namespace SharedBook.Models.Books
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;
    using Services.Books;

    public class BookViewModel : BookServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

       public string Author { get; init; }

        public Genre Genre { get; init; }

        public string Description { get; init; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        public City Location { get; set; }

        public string UserId { get; set; }

        public BookStatus Status { get; set; }
    }
}
