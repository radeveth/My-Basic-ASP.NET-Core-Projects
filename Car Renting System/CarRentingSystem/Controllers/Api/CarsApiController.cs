namespace CarRentingSystem.Controllers.Api
{

    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Services.Cars;
    using CarRentingSystem.Models.Api.Cars;

    [Route("api/cars/")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        private readonly ICarService carService;

        public CarsApiController(ICarService carService)
        {
            this.carService = carService;
        }

        // Example Api
        //[HttpGet]
        //[Route("")] 
        //[Route("{action}")]
        //public ActionResult<IEnumerable<CarResponseModel>> AllCars()
        //{
        //    IEnumerable<CarResponseModel> cars = this.dbContext
        //        .Cars
        //        .Select(c => new CarResponseModel()
        //        {
        //            Id = c.Id,
        //            Model = c.Model,
        //            Brand = c.Brand,
        //            ImageUrl = c.ImageUrl,
        //            Year = c.Year,
        //            Category = c.Category.Name,
        //        });

        //    if (!cars.Any())
        //    {
        //        return NotFound();
        //    }

        //    return cars.ToList();
        //}

        // Example Api
        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<CarResponseModel> Car(int id)
        //{
        //    var car = this.dbContext
        //       .Cars
        //       .Select(c => new CarResponseModel()
        //       {
        //           Id = c.Id,
        //           Model = c.Model,
        //           Brand = c.Brand,
        //           ImageUrl = c.ImageUrl,
        //           Year = c.Year,
        //           Category = c.Category.Name
        //       })
        //       .FirstOrDefault(c => c.Id == id);

        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    return car;
        //}

        [HttpGet]
        [Route("all")]
        public ActionResult<CarQueryServiceModel> All([FromQuery] AllCarsApiRequestModel query)
        {
            CarQueryServiceModel carQueryServiceModel = carService.All(query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.CarsPerPage);

            return carQueryServiceModel;
            
        }
    }
}