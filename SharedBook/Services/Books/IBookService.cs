namespace SharedBook.Services.Books
{
    using Models.Books;

    public interface IBookService
    {
        BookQueryServiceModel All(
            string location,
            string genre,
            string searchTerm,
            string status,
            BookSorting sorting,
            int currentPage,
            int booksPerPage
            );
    }
}
