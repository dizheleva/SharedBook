namespace SharedBook.Services.Books
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    public class BookServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Author { get; init; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        public BookStatus Status { get; set; }
    }
}
