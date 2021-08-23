namespace SharedBook.Areas.Admin.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Services.Books;

    public class BooksController : AdminController
    {
        private readonly IBookService books;
        private readonly SharedBookDbContext data;

        //public BooksController(IBookService books) => this.books = books;
        public BooksController(SharedBookDbContext data) => this.data = data;

        public IActionResult All()
        {
            var books = this.data.Books;

            return View(books);
        }

        public IActionResult ChangeVisibility(int id)
        {
            //this.books.ChangeVisility(id);

            return RedirectToAction(nameof(All));
        }
    }
}
