namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Models.Api;
    
    [Route("api/statistics/")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly CarRentingDbContext dbContext;

        public StatisticsApiController(CarRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<StatisticsResponseModel> GetStatistics()
        {
            return new StatisticsResponseModel()
            {
                TotalCars = this.dbContext.Cars.Count(),
                TotalRents = 0,
                TotalUsers = this.dbContext.Users.Count()
            };
        }

    }
}
