namespace SharedBook.Services.Books
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    public class BookDetailsServiceModel : BookServiceModel
    {

        //public int Id { get; init; }

        //public string Title { get; init; }

        //public string Author { get; init; }

        //[Display(Name = "Image URL")]
        //public string ImageUrl { get; init; }

        public Genre Genre { get; init; }

        public City Location { get; set; }

        //public BookStatus Status { get; set; }

        [Display(Name = "Owner Email")]
        public string Owner { get; set; }

        public string Description { get; init; }

        public int Shares { get; set; }
    }
}
