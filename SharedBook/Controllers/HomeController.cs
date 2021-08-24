namespace SharedBook.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Models;
    using Services.Books;
    using Services.Statistics;

    public class HomeController : Controller
    {
        private readonly IBookService books;
        private readonly IStatisticsService statistics;
        private readonly IMemoryCache cache;

        public HomeController(IBookService books, IStatisticsService statistics, IMemoryCache cache)
        {
            this.books = books;
            this.statistics = statistics;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            const string latestBooksCacheKey = "LatestBooksCacheKey";

            var latestBooks = this.cache.Get<List<BookServiceModel>>(latestBooksCacheKey);

            if (latestBooks == null)
            {
                latestBooks = this.books
                    .Latest()
                    .ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                this.cache.Set(latestBooksCacheKey, latestBooks, cacheOptions);
            }

            return View(latestBooks);
        }

        public IActionResult About() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
