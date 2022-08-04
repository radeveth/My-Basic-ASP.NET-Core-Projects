namespace CarRentingSystem.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        [Key]
        public int Id { get; init; }
        
        [Required]
        [MaxLength(DataConstants.CarBarndMaxLength)]
        public string Brand { get; set; }
        
        [Required]
        [MaxLength(DataConstants.CarModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DataConstants.CarDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(DataConstants.UrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        // In database range validation does not matter 
        public int Year { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
