namespace SharedBook.Controllers
{
    using System.IO;
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
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

        public IActionResult Add() => View(new AddBookFormModel
        {
            //Locations = this.GetLocations()
        });


        [HttpPost]
        public IActionResult Add(AddBookFormModel book, IFormFile image)
        {
            byte[] imageBytes = null;

            if (image != null)
            {
                if (image.Length > 2 * 1024 * 1024)
                {
                    this.ModelState.AddModelError("Image", "Upload an image with maximum size 2 MB");
                }
                else
                {
                    var imageInMemory = new MemoryStream();
                    image.CopyTo(imageInMemory);
                    imageBytes = imageInMemory.ToArray();
                }
            }
            
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var userId = "ooo01";

            var bookData = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                ImageUrl = book.ImageUrl ?? imageBytes?.ToString(),
                Description = book.Description,
                OwnerId = userId,
                Status = BookStatus.Available,
                Location = this.data.Users.Where(u=> u.Id == userId).Select(c => c.Address.City).ToString()
            };

            this.data.Books.Add(bookData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        // private IEnumerable<BookLocationViewModel> GetLocations() =>
        //     this.data
        //         .Locations
        //         .Select(l => new BookLocationViewModel
        //         {
        //             Id = l.Id,
        //             City = l.City
        //         })
        //         .ToList();
    }
}
