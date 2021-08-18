namespace SharedBook.Controllers
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services.Books;

    public class BooksController : Controller
    {
        private readonly IBookService books;
        private readonly SharedBookDbContext data;

        public BooksController(IBookService books, SharedBookDbContext data)
        {
            this.books = books;
            this.data = data;
        }

        public IActionResult All([FromQuery]AllBooksQueryModel query)
        {
            var queryResult = this.books.All(
                query.Location.ToString(),
                query.Genre.ToString(),
                query.SearchTerm,
                query.Status.ToString(),
                query.Sorting,
                query.CurrentPage,
                AllBooksQueryModel.BooksPerPage);
            
            query.TotalBooks = queryResult.TotalBooks;
            query.Books = queryResult.Books;

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            var user= this.data.Users.FirstOrDefault(u => u.Id == this.User.GetId());

            if (user.UserStatus == UserStatus.Active)
            {
                return RedirectToAction("Add");
            }

            return View(new AddBookFormModel
            {

            });
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(AddBookFormModel book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var bookData = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                ImageUrl = book.ImageUrl,
                Description = book.Description,
                OwnerId = this.User.GetId(),
                Status = BookStatus.Available,
                Location = book.Location
            };

            this.data.Books.Add(bookData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }
    }
}
