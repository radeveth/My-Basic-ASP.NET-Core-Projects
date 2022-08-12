namespace CarRentingSystem.Controllers
{

    using CarRentingSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Models.Dealers;
    using CarRentingSystem.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using CarRentingSystem.Services.Dealers;
    using CarRentingSystem.Models.Cars;
    using CarRentingSystem.Services.Cars;

    public class DealersController : Controller
    {
        private readonly CarRentingDbContext dbCotext;
        private readonly IDealerService dealerService;

        public DealersController(CarRentingDbContext dbCotext, IDealerService service)
        {
            this.dealerService = service;
            this.dbCotext = dbCotext;
        }

        [Authorize]
        public IActionResult Become()
        {
            // TODO: Check if user already is dealer and remove become dealer link if it is

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeDealerFormModel dealer)
        {
            if (UserIsDealerAlready())
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.View(dealer);
            }


            Dealer dealerData = new Dealer()
            {
                Name = dealer.Name,
                PhoneNumber = dealer.PhoneNumber,
                UserId = this.GetUserId()
            };

            this.dbCotext.Dealers.Add(dealerData);
            this.dbCotext.SaveChanges();

            return RedirectToAction(nameof(CarsController.All), "Cars");
        }

        public IActionResult ViewOwnCars()
        {
            return this.View();
        }

        private bool UserIsDealerAlready()
            => this.dbCotext
                .Dealers
                .Any(d => d.UserId == ClaimsPrincipalExtensions.GetId(this.User));

        private string GetUserId()
        {
            return ClaimsPrincipalExtensions.GetId(this.User);
        }
    }
}