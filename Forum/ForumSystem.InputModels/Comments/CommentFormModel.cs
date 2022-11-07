namespace ForumSystem.InputModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using static ForumSystem.Data.Common.DataValidation.CommentValidation;

    public class CommentFormModel
    {
        [Required(ErrorMessage = "Content field is required.")]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = "Content should be between {2} and {1} symbols.")]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? ParentId { get; set; }
    }
}
