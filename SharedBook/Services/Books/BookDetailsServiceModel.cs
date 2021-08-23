namespace SharedBook.Services.Books
{
    using Data.Models.Enums;

    public class BookDetailsServiceModel : BookServiceModel
    {
        public City Location { get; set; }

        public Genre? Genre { get; init; }

        public string Owner { get; set; }

        public string Description { get; init; }

        public int Shares { get; set; }
    }
}
