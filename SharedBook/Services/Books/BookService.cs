namespace SharedBook.Services.Books
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Models.Books;

    public class BookService : IBookService
    {

        private readonly IConfigurationProvider mapper;
        private readonly SharedBookDbContext data;

        public BookService(SharedBookDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        } 
        public BookQueryServiceModel All(
            City location, 
            Genre genre, 
            string searchTerm, 
            BookStatus status, 
            BookSorting sorting, 
            int currentPage, 
            int booksPerPage,
            bool publicOnly = true
            )
        {
            if (!this.data.Books.Any(b => b.IsPublic || !publicOnly))
            {
                return new BookQueryServiceModel
                {
                    TotalBooks = 0,
                    CurrentPage = currentPage,
                    BooksPerPage = booksPerPage
                };
            }

            var booksQuery = this.data.Books.Where(b => !publicOnly || b.IsPublic);
            
            if (genre != 0)
            {
                booksQuery = booksQuery.Where(b =>
                    b.Genre.ToString().ToLower().Contains(searchTerm.ToLower()));
            }

            if (status != 0)
            {
                booksQuery = booksQuery.Where(b =>
                    b.Status.ToString().ToLower().Contains(searchTerm.ToLower()));
            }

            if (location != 0)
            {
                booksQuery = booksQuery.Where(b =>
                    b.Location.ToString().ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                booksQuery = booksQuery.Where(b =>
                    b.Title.ToLower().Contains(searchTerm.ToLower())
                    || b.Author.ToLower().Contains(searchTerm.ToLower())
                );
            }

            booksQuery = sorting switch
            {
                BookSorting.Location => booksQuery.OrderBy(b => b.Location),
                BookSorting.Status => booksQuery.OrderBy(b => b.Status),
                BookSorting.Owner => booksQuery.OrderBy(b => b.UserId),
                BookSorting.Genre => booksQuery.OrderBy(b => b.Genre),
                _ => booksQuery.OrderByDescending(b => b.Id)
            };

            var totalBooks = booksQuery.Count();

            var books = GetBooks(booksQuery
                 .Skip((currentPage - 1) * booksPerPage)
                 .Take(booksPerPage));

            return new BookQueryServiceModel
            {
                TotalBooks = totalBooks,
                CurrentPage = currentPage,
                BooksPerPage = booksPerPage,
                Books = books
            };
        }
        
        public int Create(
            string title, 
            string author, 
            string description, 
            string imageUrl, 
            City location, 
            Genre genre, 
            BookStatus status, 
            string userId)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Description = description,
                ImageUrl = imageUrl,
                Location = location,
                Genre = genre,
                Status = status,
                UserId = userId,
                IsPublic = false
            };

            this.data.Books.Add(book);
            this.data.SaveChanges();

            return book.Id;
        }

        public bool Edit(
            int id, 
            string title, 
            string author, 
            string description,
            string imageUrl, 
            City location, 
            Genre genre, 
            BookStatus status, 
            string userId,
            bool isPublic)
        {
            var book = this.data.Books.Find(id);

            if (book == null || book.UserId != userId)
            {
                return false;
            }

            book.Title = title;
            book.Author = author;
            book.Description = description;
            book.ImageUrl = imageUrl;
            book.Location = location;
            book.Genre = genre;
            book.Status = status;
            book.IsPublic = isPublic;

            this.data.SaveChanges();

            return true;
        }

        public bool Delete(int bookId, string userId)
        {
            var book = this.data.Books.Find(bookId);

            if (book == null || book.UserId != userId)
            {
                return false;
            }

            this.data.Books.Remove(book);

            this.data.SaveChanges();

            return true;
        }

        public BookDetailsServiceModel Details(int id)
            => this.data
                .Books
                .Where(b => b.Id == id)
                .ProjectTo<BookDetailsServiceModel>(this.mapper)
                .FirstOrDefault();
        
        public IEnumerable<BookServiceModel> Latest()
            => this.data
                .Books
                .Where(c => c.IsPublic)
                .OrderByDescending(b => b.Id)
                .ProjectTo<BookServiceModel>(this.mapper)
                .Take(5)
                .ToList();

        private IEnumerable<BookDetailsServiceModel> GetBooks(IQueryable<Book> bookQuery)
            => bookQuery
                .ProjectTo<BookDetailsServiceModel>(this.mapper)
                .ToList();

        public IEnumerable<BookDetailsServiceModel> BooksByUser(string userId)
            => GetBooks(this.data
                .Books
                .Where(c => c.User.Id == userId));

        public bool IsOwnedByUser(int bookId, string userId)
            => this.data
                .Books
                .Any(b => b.Id == bookId && b.UserId == userId);

        public IEnumerable<string> AllTitles()
            => this.data
                .Books
                .Select(b => b.Title)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

        public void ChangeVisibility(int id)
        {
            var book = this.data.Books.Find(id);

            book.IsPublic = !book.IsPublic;

            this.data.SaveChanges();
        }
    }
}
