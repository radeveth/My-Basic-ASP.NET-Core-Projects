namespace CarRentingSystem.Services.Statistics
{
    
    using CarRentingSystem.Data;
    
    public class StatisticsService : IStatisticsService
    {
        private readonly CarRentingDbContext dbContext;

        public StatisticsService(CarRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StatisticsServiceModel Total()
        {
            return new StatisticsServiceModel()
            {
                TotalCars = this.dbContext.Cars.Count(),
                TotalUsers = this.dbContext.Users.Count(),
                TotalRents = 0,
            };
        }
    }
}
