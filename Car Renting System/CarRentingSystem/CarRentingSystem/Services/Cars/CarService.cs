namespace CarRentingSystem.Services.Cars
{
    using System.Linq;
    using CarRentingSystem.Data;
    using CarRentingSystem.Models.Cars;
    using System.Collections.Generic;

    public class CarService : ICarService
    {
        private readonly CarRentingDbContext dbContext;

        public CarService(CarRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CarQueryServiceModel All
            (string brand, 
            string searchTerm, 
            CarSorting sorting, 
            int currentPage, 
            int carsPerPage)
        {
            var carsQuery = this.dbContext.Cars.AsQueryable();

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
                .Select(c => new CarServiceModel()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                    Category = c.Category.Name
                });

            int totalCars = carsQuery.Count();

            return new CarQueryServiceModel()
            {
                TotalCars = totalCars,
                CurrentPage = currentPage,
                CarsPerPage = carsPerPage,
                Cars = cars
            };
        }

        public IEnumerable<string> AllCarBrands()
            => this.dbContext
            .Cars.Select(c => c.Brand)
            .Distinct()
            .OrderBy(br => br)
            .ToList();
    }
}
