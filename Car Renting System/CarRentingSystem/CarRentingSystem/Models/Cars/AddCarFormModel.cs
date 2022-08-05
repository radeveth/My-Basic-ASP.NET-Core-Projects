namespace CarRentingSystem.Models.Cars
{

    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using System.ComponentModel.DataAnnotations;
    
    public class AddCarFormModel
    {
        public AddCarFormModel()
        {
            this.Categories = new List<CarCategoryViewModel>();
        }

        [Required]
        [StringLength(
            DataConstants.CarBarndMaxLength, 
            MinimumLength = DataConstants.CarBarndMinLength,
            ErrorMessage = "Brand must be at least {2} symbols.")]
        public string Brand { get; init; }

        [Required]
        [StringLength(
            DataConstants.CarModelMaxLength,
            MinimumLength = DataConstants.CarBarndMinLength,
            ErrorMessage = "Model must be at least {2} symbols.")]
        public string Model { get; init; }

        [Required]
        [StringLength
            (DataConstants.CarDescriptionMaxLength,
             MinimumLength = DataConstants.CarDescriptionMinLength,
            ErrorMessage = "Description must be with minimum length of {2}.")]
        public string Description { get; init; }

        [Url]
        [Required]
        [Display(Name = "Image Url")]
        [StringLength(DataConstants.UrlMaxLength)]
        public string ImageUrl { get; init; }

        [Required(ErrorMessage = "The Year field is required.")]
        [Range(DataConstants.CarMinYear, DataConstants.CarMaxYear)]
        public int Year { get; init; }
        
        [Display(Name = "Category")]
        public  int CategoryId { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }
    }
}
