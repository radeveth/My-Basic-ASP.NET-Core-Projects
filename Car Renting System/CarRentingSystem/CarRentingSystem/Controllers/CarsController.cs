namespace CarRentingSystem.Controllers
{

    using System.Linq;
    using CarRentingSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Models.Cars;
    using CarRentingSystem.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;
    using CarRentingSystem.Infrastructure;

    public class CarsController : Controller
    {
        private readonly CarRentingDbContext dbContext;

        public CarsController(CarRentingDbContext dbCotext)
            => this.dbContext = dbCotext;

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
            var cars = this.dbContext.Cars.AsQueryable();
            query.Brands = cars
                .Select(c => c.Brand)
                .Distinct()
                .OrderBy(c => c);

            // Sorting by default is by date (newest)
            cars = query.Sorting switch
            {
                CarSorting.DateCreatedOldest => cars.OrderBy(c => c.Id),
                CarSorting.Year => cars.OrderByDescending(c => c.Year),
                CarSorting.Brand => cars.OrderByDescending(c => c.Brand),
                CarSorting.Model => cars.OrderByDescending(c => c.Model),
                CarSorting.BrandAndModel => cars
                    .OrderByDescending(c => c.Brand).ThenBy(c => c.Model),
                CarSorting.ModelAndBrand => cars
                    .OrderByDescending(c => c.Model).ThenBy(c => c.Brand),
                _ => cars.OrderByDescending(c => c.Id)
            };

            if (!String.IsNullOrEmpty(query.Brand))
            {
                cars = cars.Where(c => c.Brand.ToLower() == query.Brand.ToLower());
            }

            if (!String.IsNullOrEmpty(query.SearchTerm))
            {
                //string[] searchTermParts = searchTerm
                //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                //    .ToArray();

                query.SearchTerm = query.SearchTerm.Replace(" ", string.Empty).ToLower();
                //string compareSearchigPattern = 

                cars = cars
                    .Where(c =>
                        (c.Brand + c.Model).ToLower().Contains(query.SearchTerm) ||
                        (c.Description.ToLower()).Contains(query.SearchTerm));
            }

            query.Cars = cars
                .Skip((query.CurrentPage - 1) * AllCarsQueryModel.CarsPerPage)
                .Take(AllCarsQueryModel.CarsPerPage)
                .Select(c => new CarListingViewModel()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                    Category = c.Category.Name
                });

            query.TotalCars = cars.Count();
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
