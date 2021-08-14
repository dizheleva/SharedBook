namespace SharedBook.Models.Home
{
    using System.Security.AccessControl;

    public class BookIndexViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Author { get; init; }

        public string ImageUrl { get; set; }
    }
}
