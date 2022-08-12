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

        IEnumerable<CarCategoryServiceModel> GetCarCategories();

        CarDetailsServiceModel Details(int id);

        bool? CategoryExists(int categoryId);

        int AddCar(CarFormModel car, int dealerId);
    }
}
