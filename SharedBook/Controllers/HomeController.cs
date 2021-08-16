namespace SharedBook.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Home;
    using Services.Statistics;

    public class HomeController : Controller
    {
        private readonly SharedBookDbContext data;
        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics, SharedBookDbContext data)
        {
            this.statistics = statistics;
            this.data = data;
        }

        public IActionResult Index()
        {
            var totalStatistics = this.statistics.Total();

            var books = this.data
                .Books
                .OrderByDescending(b => b.Id)
                .Select(b => new BookIndexViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    //Genre = b.Genre,
                    //Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    //Location = b.Location,
                    //Owner = b.Owner.FirstName + " " + b.Owner.LastName,
                    //Status = b.Status.ToString()
                })
                .Take(5)
                .ToList();

            return View(new IndexViewModel
            {
                TotalUsers = totalStatistics.TotalUsers,
                TotalShares = totalStatistics.TotalShares,
                TotalBooks = totalStatistics.TotalBooks,
                Books = books
            });
        }

        public IActionResult About() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
