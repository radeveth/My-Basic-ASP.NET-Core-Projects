namespace CarRentingSystem.Services.Cars
{
    public class CarDetailsServiceModel : CarServiceModel
    {
        public string Description { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
