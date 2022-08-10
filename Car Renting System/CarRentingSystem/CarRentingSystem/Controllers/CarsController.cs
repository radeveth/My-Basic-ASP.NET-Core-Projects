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

    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly CarRentingDbContext dbContext;
        public CarsController(CarRentingDbContext dbContext, ICarService carService)
        {
            this.carService = carService;
            this.dbContext = dbContext;
        }

        // Model Biding steps:
        //   1. Method for GET http where we give the view model that will be show 
        //   2. Method for POST http where get the given data from form
        //   3. Validation steps
        //   4. Return same View with same view model or Redirect...
        [Authorize]
        public IActionResult Add()
        {
            if (!this.UserIsDelaer())
            {
                return RedirectToAction
                    (nameof(DealersController.Become), "Dealers");
            }

            return this.View(new AddCarFormModel()
            { Categories = GetCarCategories() });
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
        [Authorize]
        [HttpPost]
        public IActionResult Add(AddCarFormModel car)
        {
            ValidateCarFormModelData(car, dbContext);

            if (!ModelState.IsValid)
            {
                car.Categories = GetCarCategories();

                return this.View(car);
            }

            var carModel = new Car()
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryId,
                DealerId = this.GetCurrentDealerId()
            };

            this.dbContext.Cars.Add(carModel);
            this.dbContext.SaveChanges();

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

        // Helpful methods

        private bool UserIsDelaer() 
            => this.dbContext
                .Dealers
                .Any(d => d.UserId == ClaimsPrincipalExtensions.GetId(this.User));

        private int GetCurrentDealerId()
            => this.dbContext
                   .Dealers
                   .Where(d => d.UserId == 
                            ClaimsPrincipalExtensions.GetId(this.User))
                   .Select(d => d.Id)
                   .FirstOrDefault();

        private IEnumerable<CarCategoryViewModel> GetCarCategories()
            => this.dbContext
                   .Categories
                   .Select(x => new CarCategoryViewModel
                   {
                       Id = x.Id,
                       Name = x.Name
                   })
                   .ToList();


        private void ValidateCarFormModelData(AddCarFormModel car, CarRentingDbContext dbContext)
        {
            Category givenCarCategory = dbContext
                .Categories
                .FirstOrDefault(x => x.Id == car.CategoryId);

            if (givenCarCategory == null)
            {
                this.ModelState
                    .AddModelError(nameof(car.CategoryId),
                    "Category does not exist!");
            }
            else if (dbContext
                .Categories
                .FirstOrDefault(x => x.Name == givenCarCategory.Name) == null)
            {
                this.ModelState
                    .AddModelError(nameof(car.CategoryId),
                    "Invalid category value for this Id!!!");
            }
        }

        private int SkipPagesLogic(AllCarsQueryModel query)
        {
            return (query.CurrentPage - 1) * AllCarsQueryModel.CarsPerPage;
        }
    }
}
