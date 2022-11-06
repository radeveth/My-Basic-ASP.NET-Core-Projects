namespace ForumSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;
    using ForumSystem.Data.Models.Enums;

    public class VoteComment : BaseModel<int>
    {
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public Comment Comment { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Vote { get; set; }
    }
}
