namespace SharedBook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
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
        public IActionResult Add(AddBookFormModel book)
        {
            return View();
        }

        private IEnumerable<BookLocationViewModel> GetLocations() =>
            this.data
                .Locations
                .Select(l => new BookLocationViewModel
                {
                    Id = l.Id,
                    City = l.City
                })
                .ToList();
    }
}
