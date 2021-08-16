namespace SharedBook.Services.Statistics
{
    using System.Linq;
    using Data;

    public class StatisticsService : IStatisticsService
    {
        public readonly SharedBookDbContext data;

        public StatisticsService(SharedBookDbContext data) => this.data = data;
        public StatisticsServiceModel Total()
        {
            var totalBooks = this.data.Books.Count();
            var totalUsers = this.data.Users.Count();
            var totalShares = this.data.SharedBooks.Count();

            return new StatisticsServiceModel
            {
                TotalShares = totalShares,
                TotalUsers = totalUsers,
                TotalBooks = totalBooks
            };
        }
    }
}
