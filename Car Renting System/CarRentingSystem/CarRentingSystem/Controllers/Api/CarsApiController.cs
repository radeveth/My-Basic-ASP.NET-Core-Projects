namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Models.Api.Cars;
    using System.Linq;

    [Route("api/cars")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        private readonly CarRentingDbContext dbContext;

        public CarsApiController(CarRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("")] 
        [Route("{action}")]
        public ActionResult<IEnumerable<CarsResponseModel>> AllCars()
        {
            IEnumerable<CarsResponseModel> cars = this.dbContext
                .Cars
                .Select(c => new CarsResponseModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    Brand = c.Brand,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Category = c.Category.Name,
                    Dealer = c.Dealer.Name,
                });

            if (!cars.Any())
            {
                return NotFound();
            }

            return cars.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CarsResponseModel> Car(int id)
        {
            var car = this.dbContext
               .Cars
               .Select(c => new CarsResponseModel()
               {
                   Id = c.Id,
                   Model = c.Model,
                   Brand = c.Brand,
                   Description = c.Description,
                   ImageUrl = c.ImageUrl,
                   Category = c.Category.Name,
                   Dealer = c.Dealer.Name,
               })
               .FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

    }
}