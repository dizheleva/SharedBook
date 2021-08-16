namespace SharedBook.Services.Books
{
    using System.Linq;
    using Data;
    using Models.Books;

    public class BookService : IBookService
    {
        private readonly SharedBookDbContext data;

        public BookService(SharedBookDbContext data) => this.data = data;
        public BookQueryServiceModel All(
            string location,
            string genre,
            string searchTerm,
            string status,
            BookSorting sorting,
            int currentPage,
            int booksPerPage
            )
        {
            var booksQuery = this.data.Books.AsQueryable();
            
            if (genre != null)
            {
                booksQuery = booksQuery.Where(b =>
                    b.Genre.ToString().ToLower().Contains(searchTerm.ToLower()));
            }

            if (status != null)
            {
                booksQuery = booksQuery.Where(b =>
                    b.Status.ToString().ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                booksQuery = booksQuery.Where(b =>
                    b.Location.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                booksQuery = booksQuery.Where(b =>
                    b.Title.ToLower().Contains(searchTerm.ToLower())
                    || b.Author.ToLower().Contains(searchTerm.ToLower())
                    || b.Genre.ToString().ToLower().Contains(searchTerm.ToLower())
                    || b.Location.ToLower().Contains(searchTerm.ToLower())
                    || b.Owner.FirstName.ToLower().Contains(searchTerm.ToLower())
                    || b.Status.ToString().ToLower().Contains(searchTerm.ToLower())
                );
            }

            booksQuery = sorting switch
            {
                BookSorting.Location => booksQuery.OrderBy(b => b.Location),
                BookSorting.Status => booksQuery.OrderBy(b => b.Status),
                BookSorting.Owner => booksQuery.OrderBy(b => b.Owner),
                BookSorting.Genre => booksQuery.OrderBy(b => b.Genre),
                _ => booksQuery.OrderByDescending(b => b.Id)
            };

            var books = booksQuery
                .Skip((currentPage - 1) * booksPerPage)
                .Take(booksPerPage)
                .Select(b => new BookServiceModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Location = b.Location,
                    Owner = b.Owner.FirstName + " " + b.Owner.LastName,
                    Status = b.Status
                })
                .ToList();

            var totalBooks = books.Count;

            return new BookQueryServiceModel
            {
                TotalBooks = totalBooks,
                CurrentPage = currentPage,
                BooksPerPage = booksPerPage
            };
        }
    }
}
