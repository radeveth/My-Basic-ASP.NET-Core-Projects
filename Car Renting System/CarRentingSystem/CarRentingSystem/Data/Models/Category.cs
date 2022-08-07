namespace CarRentingSystem.Data.Models
{

    using System.ComponentModel.DataAnnotations;

    using static DataConstants.CategoryConstants;

    public class Category
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; init; }
    }
}
