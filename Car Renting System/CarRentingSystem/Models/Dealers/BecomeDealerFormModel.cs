namespace CarRentingSystem.Models.Dealers
{
    using CarRentingSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    
    using static Data.DataConstants.DealerConstants;
    
    public class BecomeDealerFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, 
            ErrorMessage = "Name must be between {2} and {1} symbols")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "The Phone Number field is required")]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength,
            ErrorMessage = "Phone Number must be with length between {2} and {1}")]
        [RegularExpression
            (@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Your phone number does not match")]
        public string PhoneNumber { get; set; }
    }
}
