namespace CarRentingSystem.Controllers.Api
{

    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Services.Statistics;

    [Route("api/statistics/")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsApiController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<StatisticsServiceModel> GetStatistics()
        {
            StatisticsServiceModel statisticsModel = statisticsService.Total();

            return statisticsModel;
        }

    }
}
