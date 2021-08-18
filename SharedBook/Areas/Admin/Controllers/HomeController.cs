namespace SharedBook.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Statistics;

    public class HomeController : AdminController
    {

        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics) => this.statistics = statistics;

        public IActionResult Index()
        {
            var totalStatistics = this.statistics.Total();

            var homeView = new HomeViewModel
            {
                MembersCount = totalStatistics.TotalUsers,
                BooksCount = totalStatistics.TotalBooks,
                SharedBooksCount = totalStatistics.TotalShares
            };

            return View(homeView);
        }
    }
}
