namespace ForumSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;
    using ForumSystem.Data.Models.Enums;

    public class VotePost : BaseModel<int>
    {
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public Post Post { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Vote { get; set; }
    }
}
