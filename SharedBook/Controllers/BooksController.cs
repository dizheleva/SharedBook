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

    public class BooksController : Controller
    {
        private readonly SharedBookDbContext data;

        public BooksController(SharedBookDbContext data) => this.data = data;

        public IActionResult Add() => View(new AddBookFormModel
        {
            //Locations = this.GetLocations()
        });

        [HttpPost]
        public IActionResult Add(AddBookFormModel book, IFormFile image)
        {
            if (image != null && image.Length > 2 * 1024 * 1024)
            {
                this.ModelState.AddModelError("Image", "The image maximum size should be 2 MB");
            }

            var imageInMemory = new MemoryStream();
            image.CopyTo(imageInMemory);
            var imageBytes = imageInMemory.ToArray();

            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var userId = "ooo01";
            var currentUser = data.Users.Select(u => u.Id == userId);

            var bookData = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                ImageUrl = book.ImageUrl,
                Description = book.Description,
                Status = BookStatus.Available,
                OwnerId = userId,
                Location = this.data.Users.Where(u=> u.Id == userId).Select(c => c.Address.City).ToString()
            };

            this.data.Books.Add(bookData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
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
