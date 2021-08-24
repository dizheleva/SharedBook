namespace SharedBook.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Books;

    public class BooksController : AdminController
    {
        private readonly IBookService books;
        //private readonly SharedBookDbContext data;

        public BooksController(IBookService books) => this.books = books;
       // public BooksController(SharedBookDbContext data) => this.data = data;

        public IActionResult List()
        {
            var books = this.books.All().Books;

            return View(books);
        }

        public IActionResult ChangeVisibility(int id)
        {
            //this.books.ChangeVisility(id);

            return RedirectToAction(nameof(List));
        }
    }
}
