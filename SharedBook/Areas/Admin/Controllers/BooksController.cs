namespace SharedBook.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Books;

    public class BooksController : AdminController
    {
        private readonly IBookService books;

        public BooksController(IBookService books) => this.books = books;

        public IActionResult List() => View(this.books.All(publicOnly: false).Books);

        public IActionResult ChangeVisibility(int id)
        {
            this.books.ChangeVisibility(id);

            return RedirectToAction(nameof(List));
        }
    }
}
