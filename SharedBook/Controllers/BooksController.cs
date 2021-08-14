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

        public IActionResult All([FromQuery]AllBooksViewModel query)
        {
            var booksQuery = this.data.Books.AsQueryable();
            
            var location = query.Location.ToString();

            if (query.Genre != null)
            {
                booksQuery = booksQuery.Where(b =>
                    b.Genre.ToString().ToLower().Contains(query.SearchTerm.ToLower()));
            }

            if (query.Status != null)
            {
                booksQuery = booksQuery.Where(b =>
                    b.Status.ToString().ToLower().Contains(query.SearchTerm.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                booksQuery = booksQuery.Where(b =>
                    b.Location.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                booksQuery = booksQuery.Where(b =>
                    b.Title.ToLower().Contains(query.SearchTerm.ToLower())
                    || b.Author.ToLower().Contains(query.SearchTerm.ToLower())
                    || b.Genre.ToString().ToLower().Contains(query.SearchTerm.ToLower())
                    || b.Location.ToLower().Contains(query.SearchTerm.ToLower())
                    || b.Owner.FirstName.ToLower().Contains(query.SearchTerm.ToLower())
                    || b.Status.ToString().ToLower().Contains(query.SearchTerm.ToLower())
                );
            }

            booksQuery = query.Sorting switch
            {
                BookSorting.Location => booksQuery.OrderBy(b => b.Location),
                BookSorting.Status => booksQuery.OrderBy(b => b.Status),
                BookSorting.Owner => booksQuery.OrderBy(b => b.Owner),
                BookSorting.Genre => booksQuery.OrderBy(b => b.Genre),
                _ => booksQuery.OrderByDescending(b => b.Id)
            };

            var books = booksQuery
                .Select(b => new BookViewModel
                {
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

            query.Books = books;

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
