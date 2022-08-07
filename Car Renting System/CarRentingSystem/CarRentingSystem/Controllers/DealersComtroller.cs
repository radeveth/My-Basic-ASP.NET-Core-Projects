namespace CarRentingSystem.Controllers
{

    using CarRentingSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using CarRentingSystem.Models.Dealers;
    using CarRentingSystem.Data.Models;

    public class DealersComtroller : Controller
    {
        private readonly CarRentingDbCotext dbCotext;

        public DealersComtroller(CarRentingDbCotext dbCotext)
        {
            this.dbCotext = dbCotext;
        }

        [Authorize]
        public IActionResult Create()
        {
            // TODO: Check if user already is dealer and remove become dealer link if it is

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(BecomeDealerFormModel dealer)
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
