namespace ForumSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;

    using static ForumSystem.Data.Common.DataValidation.NotificationValidation;

    public class Notification : BaseModel<int>
    {
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public int ToUserId { get; set; }

        public ApplicationUser ToUser { get; set; }
    }
}
