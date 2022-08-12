namespace CarRentingSystem.Services.Dealers
{

    using CarRentingSystem.Models.Cars;
    using System.ComponentModel.DataAnnotations;
    
    public class AllDealerCarsQueryServiceModel
    {
        public const int CarsPerPage = 3;

        public string Brand { get; set; }
        public IEnumerable<string> Brands { get; set; }

        public int TotalCars { get; set; }
        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }
        public CarSorting Sorting { get; set; }
        public IEnumerable<DealerCarServiceModel> Cars { get; set; }
    }
}
