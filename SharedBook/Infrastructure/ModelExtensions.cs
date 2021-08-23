namespace SharedBook.Infrastructure
{
    using Services.Books;

    public static class ModelExtensions
    {
        public static string GetInformation(this BookServiceModel book)
            => book.Title + " - " + book.Author + " - " + book.Status;
    }
}
