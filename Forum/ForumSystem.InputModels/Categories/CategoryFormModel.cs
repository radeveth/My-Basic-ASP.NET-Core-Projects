namespace ForumSystem.InputModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static ForumSystem.Data.Common.DataValidation.CategoryValudation;

    public class CategoryFormModel
    {
        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name should be between {2} and {1} symbols.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field is required.")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Name should be between {2} and {1} symbols.")]
        public string Description { get; set; }

        [Url]
        [Required(ErrorMessage = "Image Url field is required.")]
        [MaxLength(ImageUrlMaxLength, ErrorMessage = "Url cannot be more than {1} symbols.")]
        public string ImageUrl { get; set; }

        [Required]
        public int CreatorId { get; set; }
    }
}
