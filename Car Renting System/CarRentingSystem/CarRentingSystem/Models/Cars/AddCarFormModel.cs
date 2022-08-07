namespace CarRentingSystem.Models.Cars
{

    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using CarRentingSystem.Models.ValidationAttributes;

    using static Data.DataConstants.CarConstants;
    using static Data.DataConstants.UrlConstants;
    

    // IValidateableObject -> Custom validation logic
    public class AddCarFormModel
    {
        public AddCarFormModel()
        {
            this.Categories = new List<CarCategoryViewModel>();
        }

        [Required]
        [StringLength(BarndMaxLength, MinimumLength = BarndMinLength,
            ErrorMessage = "Brand must be at least {2} symbols.")]
        public string Brand { get; init; }

        [Required]
        [StringLength(ModelMaxLength,MinimumLength = BarndMinLength,
            ErrorMessage = "Model must be at least {2} symbols.")]
        public string Model { get; init; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = "Description must be with minimum length of {2}.")]
        public string Description { get; init; }

        //[IsValidUrlAttribute(nameof(ImageUrl))]
        [Url(ErrorMessage = "The Image Url field is not valid.")]
        [Required]
        [Display(Name = "Image Url")]
        [StringLength(UrlMaxLength)]
        public string ImageUrl { get; init; }

        [Required(ErrorMessage = "The Year field is required.")]
        [Range(MinYear, MaxYear)]
        public int Year { get; init; }
        
        [Display(Name = "Category")]
        public  int CategoryId { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }
    }
}
