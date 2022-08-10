namespace CarRentingSystem.Controllers
{

    using System.Diagnostics;
    using CarRentingSystem.Data;
    using CarRentingSystem.Models;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Models.Home;
    using CarRentingSystem.Services.Statistics;

    public class HomeController : Controller
    {
        private readonly CarRentingDbContext dbContext;
        private readonly IStatisticsService statisticsService;

        public HomeController
            (CarRentingDbContext dbContext, IStatisticsService statisticsService)
        {
            this.dbContext = dbContext;
            this.statisticsService = statisticsService;
        }

        public IActionResult Index()
        {
            List<CarIndexViewModel> cars = this.dbContext
               .Cars
               .OrderByDescending(c => c.Id)
               .Take(3)
               .Select(c => new CarIndexViewModel()
               {
                   Id = c.Id,
                   Brand = c.Brand,
                   Model = c.Model,
                   ImageUrl = c.ImageUrl,
                   Year = c.Year
               })
               .ToList();

            StatisticsServiceModel statistics = this.statisticsService.Total();

            return this.View(new IndexViewModel()
            {
                TotalCars = statistics.TotalCars,
                TotalUsers = statistics.TotalUsers,
                Cars = new List<CarIndexViewModel>(cars)
            });

        }


        [ResponseCache
            (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => View(new ErrorViewModel 
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}