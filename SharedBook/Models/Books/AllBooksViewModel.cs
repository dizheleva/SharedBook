namespace SharedBook.Models.Books
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    public class AllBooksViewModel
    {
        [Required]
        public int Id { get; init; }

        [Required]
        public string Title { get; init; }

        [Required]
        public string Author { get; init; }

        public Genre Genre { get; init; }

        public string Description { get; init; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        public string Location { get; set; }

        public string Owner { get; set; }

        public string Status { get; set; }
    }
}
