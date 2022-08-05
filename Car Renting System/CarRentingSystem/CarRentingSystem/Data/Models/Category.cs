namespace CarRentingSystem.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    
    public class Category
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; init; }
    }
}
