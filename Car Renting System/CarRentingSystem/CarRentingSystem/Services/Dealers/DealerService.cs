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


        public DealerService(CarRentingDbContext dbContex)
        {
            this.dbContext = dbContex;
        }

        public bool IsDealer(string userId)
        {
            return this.dbContext
                .Dealers
                .Any(d => d.UserId == userId);
        }
    }
}
