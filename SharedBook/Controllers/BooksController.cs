namespace SharedBook.Controllers
{
    using AutoMapper;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services.Books;
    using Services.Users;

    using static WebConstants;

    public class BooksController : Controller
    {
        private readonly IBookService books;
        private readonly IUserService users;
        private readonly IMapper mapper;

        public BooksController(IBookService books, IUserService users, IMapper mapper)
        {
            this.books = books;
            this.users = users;
            this.mapper = mapper;
        }

        public IActionResult All([FromQuery]AllBooksQueryModel query)
        {
            var queryResult = this.books.All(
                query.Location,
                query.Genre,
                query.SearchTerm,
                query.Status,
                query.Sorting,
                query.CurrentPage,
                AllBooksQueryModel.BooksPerPage);
            
            query.TotalBooks = queryResult.TotalBooks;
            query.Books = queryResult.Books;

            return View(query);
        }

        public IActionResult Details(int id, string information)
        {
            var book = this.books.Details(id);

            if (information != book.GetInformation())
            {
                return BadRequest();
            }

            return View(book);
        }

        [Authorize]
        public IActionResult Add()
        {
            var userId = this.User.GetId();

            if (!this.users.IsRegisteredUser(userId))
            {
                return RedirectToAction(nameof(UsersController.Register), "Users");
            }
            
            return View(new BookFormModel());
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Add(BookFormModel book)
        {
            var userId = this.User.GetId();

            if (!this.users.IsActiveUser(userId))
            {
                return Unauthorized(); ;
            }

            if (!ModelState.IsValid)
            {
                this.TempData[GlobalMessageKey] = "Book not added!";

                return View(book);
            }

            var bookId = this.books.Create
                (
                book.Title,
                book.Author,
                book.Description,
                book.ImageUrl,
                book.Location,
                book.Genre,
                book.Status,
                userId);


            this.TempData[GlobalMessageKey] = $"New book successfully added!{(this.User.IsAdmin() ? string.Empty : " Waiting for approval.")}";

            return RedirectToAction(nameof(Details), new { id = bookId});
        }

        [Authorize]
        public IActionResult Edit(int bookId)
        {
            var userId = this.User.GetId();

            if (!this.users.IsRegisteredUser(userId) && !User.IsAdmin())
            {
                return RedirectToAction(nameof(UsersController.Register), "Users");
            }

            if (!this.books.IsOwnedByUser(bookId, userId) && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var book = this.books.Details(bookId);

            var bookForm = this.mapper.Map<BookFormModel>(book);

            return View(bookForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, BookFormModel book)
        {
            var userId = this.User.GetId();

            if (!this.users.IsRegisteredUser(userId) && !User.IsAdmin())
            {
                return RedirectToAction(nameof(UsersController.Register), "Users");
            }

            if (!this.books.IsOwnedByUser(id, userId) && !User.IsAdmin())
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                TempData[GlobalMessageKey] = "Book not edited!";

                return View(book);
            }

            var edited = this.books.Edit(
                id,
                book.Title,
                book.Author,
                book.Description,
                book.ImageUrl,
                book.Location,
                book.Genre,
                book.Status,
                userId);

            if (!edited)
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = $"Book successfully edited!{(this.User.IsAdmin() ? string.Empty : " Waiting for approval.")}";

            return RedirectToAction(nameof(Details), new { id});
        }

        [Authorize]
        public IActionResult Owned()
        {
            var myBooks = this.books.BooksByUser(this.User.GetId());

            return View(myBooks);
        }
    }
}
