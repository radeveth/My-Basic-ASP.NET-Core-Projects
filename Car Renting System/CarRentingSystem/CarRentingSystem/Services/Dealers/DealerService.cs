namespace CarRentingSystem.Services.Dealers
{
    
    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Infrastructure;
    using CarRentingSystem.Models.Cars;
    using CarRentingSystem.Services.Cars;
    using Microsoft.AspNetCore.Identity;

    public class DealerService : IDealerService
    {
        private readonly CarRentingDbContext dbContext;
        private readonly UserManager<IdentityUser> userManagaer;


        public DealerService(CarRentingDbContext dbContex, UserManager<IdentityUser> userManagaer)
        {
            this.dbContext = dbContex;
            this.userManagaer = userManagaer;
        }

        public AllDealerCarsQueryServiceModel ViewOwnCars
            (string id, 
            string brand,
            string searchTerm,
            CarSorting sorting,
            int currentPage,
            int carsPerPage)
        {
            Dealer dealerQuery = this.dbContext
                .Dealers
                .AsQueryable()
                .FirstOrDefault(d => d.UserId == id);

            var carsQuery = dealerQuery.Cars.AsQueryable();

            // Sorting by default is by date (newest)
            carsQuery = sorting switch
            {
                CarSorting.DateCreatedOldest => carsQuery.OrderBy(c => c.Id),
                CarSorting.Year => carsQuery.OrderByDescending(c => c.Year),
                CarSorting.Brand => carsQuery.OrderByDescending(c => c.Brand),
                CarSorting.Model => carsQuery.OrderByDescending(c => c.Model),
                CarSorting.BrandAndModel => carsQuery
                    .OrderByDescending(c => c.Brand).ThenBy(c => c.Model),
                CarSorting.ModelAndBrand => carsQuery
                    .OrderByDescending(c => c.Model).ThenBy(c => c.Brand),
                _ => carsQuery.OrderByDescending(c => c.Id)
            };

            if (!String.IsNullOrEmpty(brand))
            {
                carsQuery = carsQuery.Where(c => c.Brand.ToLower() == brand.ToLower());
            }

            if (!String.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Replace(" ", string.Empty).ToLower();

                carsQuery = carsQuery
                    .Where(c =>
                        (c.Brand + c.Model).ToLower().Contains(searchTerm) ||
                        (c.Description.ToLower()).Contains(searchTerm));
            }

            var cars = carsQuery
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .Select(c => new DealerCarServiceModel()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                    Category = c.Category.Name
                });

            int totalCars = carsQuery.Count();

            return new AllDealerCarsQueryServiceModel()
            {
                Cars = cars,
                TotalCars = totalCars,
                CurrentPage = currentPage
            };


            
        }

        private bool UserIsDealerAlready(string id)
            => this.dbContext
                .Dealers
                .Any(d => d.UserId == id);

        public IEnumerable<string> AllCarBrands()
            => this.dbContext
            .Cars.Select(c => c.Brand)
            .Distinct()
            .OrderBy(br => br)
            .ToList();
    }
}
