namespace ForumSystem.Data.Models
{
    using System.Collections;
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

        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        // This is relation one to many
        // One post have one category
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        // One post can have many comments
        public virtual ICollection<Comment> Comments { get; set; }

        // One post can have many votes by users
        public virtual ICollection<VotePost> VotePosts { get; set; }
    }
}
