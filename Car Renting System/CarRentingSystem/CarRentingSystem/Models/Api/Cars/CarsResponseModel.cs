namespace CarRentingSystem.Models.Api.Cars
{
    
    using CarRentingSystem.Data.Models;
    
    public class CarsResponseModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public string Dealer { get; set; }
    }
}
