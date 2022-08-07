namespace CarRentingSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.DealerConstants;

    public class Dealer
    {
        public Dealer()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
