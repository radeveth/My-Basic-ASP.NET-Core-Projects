namespace CarRentingSystem.Models.Home
{
    using System.Collections;
    public class IndexViewModel
    {
        public int TotalCars { get; set; }
        public int TotalUsers { get; set; }
        public int TotalRents { get; set; }

        public IEnumerable<CarIndexViewModel> Cars { get; set; }
    }
}
