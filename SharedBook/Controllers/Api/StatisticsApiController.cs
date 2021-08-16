namespace SharedBook.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Statistics;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statistics;

        public StatisticsApiController(IStatisticsService statistics) => this.statistics = statistics;

        [HttpGet]
        public StatisticsServiceModel GetStatistics() => this.statistics.Total();
    }
}
