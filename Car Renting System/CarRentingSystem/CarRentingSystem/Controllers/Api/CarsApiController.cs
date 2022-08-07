namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Data.Models;
    
    [Route("api/{controller}")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        private readonly CarRentingDbContext dbContext;

        public CarsApiController(CarRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("{action}")]
        public ActionResult<IEnumerable<Car>> Cars()
        {
            IEnumerable<Car> cars = this.dbContext.Cars.ToList();

            if (!cars.Any())
            {
                return NotFound();
            }

            return this.dbContext.Cars.ToList();
        }


    }
}