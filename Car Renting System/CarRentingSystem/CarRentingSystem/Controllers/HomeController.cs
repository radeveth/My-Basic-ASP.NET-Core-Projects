namespace CarRentingSystem.Controllers
{

    using System.Diagnostics;
    using CarRentingSystem.Data;
    using CarRentingSystem.Models;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Models.Home;
    
    public class HomeController : Controller
    {
        private readonly CarRentingDbContext dbContext;

        public HomeController(CarRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            int totalCars = this.dbContext.Cars.Count();
            int totalUsers = this.dbContext.Users.Count();

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

            return this.View(new IndexViewModel()
            {
                TotalCars = totalCars,
                TotalUsers = totalUsers,
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