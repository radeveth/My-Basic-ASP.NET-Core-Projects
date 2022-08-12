using CarRentingSystem.Models.Cars;

namespace CarRentingSystem.Services.Cars
{
    public interface ICarService
    {
        CarQueryServiceModel All
            (string brand, 
            string searchTerm, 
            CarSorting sorting, 
            int currentPage, 
            int carsPerPage,
            string userId = null);

        IEnumerable<string> AllCarBrands();
    }
}
