namespace ForumSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;

    using static ForumSystem.Data.Common.DataValidation.CommentValidation;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.VoteComments = new HashSet<VoteComment>();
        }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        // This relation is one to many
        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        // This relation is one to many
        // One comment have one user and one user can have many comments
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<VoteComment> VoteComments { get; set; }

        // This is self relation
        // One comment can have one parent comment and one comment can have many child comment
        [ForeignKey(nameof(Comment))]
        public int? ParentId { get; set; }

        public Comment Parent { get; set; }
    }
}
