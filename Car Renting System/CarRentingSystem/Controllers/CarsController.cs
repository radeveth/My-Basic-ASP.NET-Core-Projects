namespace CarRentingSystem.Controllers
{

    using System.Linq;
    using CarRentingSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Models.Cars;
    using CarRentingSystem.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using CarRentingSystem.Infrastructure;
    using CarRentingSystem.Services.Cars;
    using Microsoft.AspNetCore.Identity;
    using CarRentingSystem.Services.Dealers;

    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly DealerService dealerService;
        private readonly UserManager<IdentityUser> userManager;

        public CarsController
            (CarRentingDbContext dbContext, 
            ICarService carService,
            DealerService dealerService,
            UserManager<IdentityUser> userManager)
        {
            this.carService = carService;
            this.userManager = userManager;
            this.dealerService = dealerService;
        }

        // Model Biding steps:
        //   1. Method for GET http where we give the view model that will be show 
        //   2. Method for POST http where get the given data from form
        //   3. Validation steps
        //   4. Return same View with same view model or Redirect...
        [Authorize]
        public IActionResult Add()
        {
            // if (!this.dealerService.IsDealer(this.GetUserId()))
            if (!this.dealerService.IsDealer(ClaimsPrincipalExtensions.GetId(this.User)))
            {
                return RedirectToAction
                    (nameof(DealersController.Become), "Dealers");
            }

            return this.View(new CarFormModel()
            { Categories = carService.GetCarCategories() });
        }

        // Validation steps:
        //   1. Attributes 
        //   2. Write custom validation logic (optional)
        //   3. Check is ModelState is Valid -> If it is not: 
        //                                      - Show user mistakes
        //                                      - Return View
        //   4. Mapping view model to database entity
        //   5. adding to database new entity and save changes
        //   6. Redirect to other page
        [HttpPost]
        [Authorize]
        public IActionResult Add(CarFormModel car)
        {
            if (!this.dealerService.IsDealer(this.GetUserId()))
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            var categoryExists = this.carService.CategoryExists(car.CategoryId);
            if (categoryExists == null)
            {
                this.ModelState
                    .AddModelError(nameof(car.CategoryId),
                    "Category does not exist!");
            }
            else if (categoryExists == false)
            {
                this.ModelState
                    .AddModelError(nameof(car.CategoryId),
                    "Invalid category value for this Id!!!");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = carService.GetCarCategories();

                return this.View(car);
            }

            int dealerId = this.dealerService.GetIdByUser(this.GetUserId());

            int createdCarId = this.carService.AddCar(car, dealerId);

            return RedirectToAction(nameof(All), "Cars");
        }

        public IActionResult All([FromQuery] AllCarsQueryModel query)
        {
            CarQueryServiceModel carQueryServiceModel = carService.All
                (query.Brand, 
                query.SearchTerm, 
                query.Sorting, 
                query.CurrentPage, 
                AllCarsQueryModel.CarsPerPage);

            query.TotalCars = carQueryServiceModel.TotalCars;
            query.CurrentPage = carQueryServiceModel.CurrentPage;
            query.Cars = carQueryServiceModel.Cars;
            query.Brands = carService.AllCarBrands();
            
            return this.View(query);
        }

        public IActionResult Mine([FromQuery] AllCarsQueryModel query)
        {
            CarQueryServiceModel carQueryServiceModel = carService.All
                (query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsPerPage,
                this.GetUserId());

            query.TotalCars = carQueryServiceModel.TotalCars;
            query.CurrentPage = carQueryServiceModel.CurrentPage;
            query.Cars = carQueryServiceModel.Cars;
            query.Brands = carService.AllCarBrands();

            return this.View(query);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.dealerService.IsDealer(this.GetUserId()))
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            var car = this.carService.Details(id);

            if (car.UserId != this.GetUserId())
            {
                return Unauthorized();
            }

            return this.View(new CarFormModel()
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryId,
                Categories = this.carService.GetCarCategories()
            }); ;
        }


        // Helpful methods

        private string GetUserId()
            => this.userManager.GetUserId(this.User);

        private int SkipPagesLogic(AllCarsQueryModel query)
            => (query.CurrentPage - 1) * AllCarsQueryModel.CarsPerPage;
    }
}
