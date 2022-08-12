namespace CarRentingSystem.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants.CarConstants;
    using static DataConstants.UrlConstants;
    public class Car
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(BarndMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        // In database range validation does not matter 
        public int Year { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}