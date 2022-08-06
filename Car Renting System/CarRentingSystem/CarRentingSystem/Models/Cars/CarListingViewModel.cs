namespace CarRentingSystem.Models.Cars
{

    using CarRentingSystem.Data.Models;
    
    public class CarListingViewModel
    {
        public int Id { get; init; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public string Category { get; set; }
    }
}
