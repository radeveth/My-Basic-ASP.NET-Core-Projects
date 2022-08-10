namespace CarRentingSystem.Services.Cars
{
    public class CarQueryServiceModel
    {
        public int TotalCars { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int CarsPerPage { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; } 
            = new List<CarServiceModel>();
    }
}
