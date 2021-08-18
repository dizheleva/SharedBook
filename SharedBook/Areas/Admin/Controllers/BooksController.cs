namespace SharedBook.Areas.Admin.Controllers
{
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Services.Books;

    public class BooksController : AdminController
    {
        private readonly IBookService books;
        private readonly SharedBookDbContext data;

        public BooksController(IBookService books, SharedBookDbContext data)
        {
            this.books = books;
            this.data = data;
        }

        public IActionResult All()
        {
            

            return View();
        }

        

        public IActionResult Update()
        {
            return View();
        }

        /*public IActionResult ChangeStatus(int id, BookStatus status)
        {
            var book = this.data.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.Status = status;
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IActionResult CheckBooksCount(IEnumerable<Book> books)
        {
            if (books == null || books.ToList().Count == 0)
            {
                return NotFound();
            }
            else
            {
                return View(books);
            }
        }

        public IActionResult Update(int id)
        {
            var book = this.data.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookVM = new BookEditViewModel
            {
                Book = book,
            };

            return View(bookVM);
        }
        */

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(BookServiceModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            this.data.Books.Add(bookModel);

            return RedirectToAction("List");
        }
        }*/

        public IActionResult Delete(int id)
        {
            var book = this.data.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            this.data.Books.Remove(book);

            return RedirectToAction("All");
        }
    }
}
