using CarRentingSystem.Models.Cars;

namespace CarRentingSystem.Services.Dealers
{
    public interface IDealerService
    {
        bool IsDealer(string userId);

        int GetIdByUser(string userId);
    }
}
