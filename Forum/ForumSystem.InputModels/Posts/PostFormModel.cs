namespace ForumSystem.InputModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using static ForumSystem.Data.Common.DataValidation.PostValidation;

    public class PostFormModel
    {

        [Required(ErrorMessage = "Title field is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Title should be between {2} and {1} symbols.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content field is required.")]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = "Content should be between {2} and {1} symbols.")]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
