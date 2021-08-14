namespace SharedBook.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Books;

    public class HomeController : Controller
    {
        private readonly SharedBookDbContext data;

        public HomeController(SharedBookDbContext data) => this.data = data;
        public IActionResult Index()
        {
            var books = this.data
                .Books
                .OrderByDescending(b => b.Id)
                .Select(b => new AllBooksViewModel
                {
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Location = b.Location,
                    Owner = b.Owner.FirstName + " " + b.Owner.LastName,
                    Status = b.Status.ToString()
                })
                .Take(5)
                .ToList();

            return View(books);
        }

        public IActionResult About() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
