namespace CarRentingSystem.Models.Cars
{
    using System.Collections.Generic;
    using CarRentingSystem.Services.Cars;
    using System.ComponentModel.DataAnnotations;

    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 3;

        public string Brand { get; set; }
        public IEnumerable<string> Brands { get; set; }

        public int TotalCars { get; set; }
        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }
        public CarSorting Sorting { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; }
    }
}
