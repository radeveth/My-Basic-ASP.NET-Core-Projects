namespace ForumSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;

    using static ForumSystem.Data.Common.DataValidation.PostValidation;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.VotePosts = new HashSet<VotePost>();
        }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        // This is relation one to many
        // One post have one category
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        // This relation is one to many
        // One post have one user and one user can have many posts
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        // One post can have many comments
        public virtual ICollection<Comment> Comments { get; set; }

        // One post can have many votes by users
        public virtual ICollection<VotePost> VotePosts { get; set; }
    }
}
