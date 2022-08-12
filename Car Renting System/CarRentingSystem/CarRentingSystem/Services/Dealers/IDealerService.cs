using CarRentingSystem.Models.Cars;

namespace CarRentingSystem.Services.Dealers
{
    public interface IDealerService
    {
        AllDealerCarsQueryServiceModel ViewOwnCars(string id,
            string brand,
            string searchTerm,
            CarSorting sorting,
            int currentPage,
            int carsPerPage);

        IEnumerable<string> AllCarBrands();

    }
}
