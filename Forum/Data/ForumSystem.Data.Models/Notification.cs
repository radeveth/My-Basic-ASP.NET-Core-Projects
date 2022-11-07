namespace ForumSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;

    using static ForumSystem.Data.Common.DataValidation.NotificationValidation;

    public class Notification : BaseModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public int ToUserId { get; set; }

        public ApplicationUser ToUser { get; set; }
    }
}
