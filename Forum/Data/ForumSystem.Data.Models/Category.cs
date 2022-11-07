namespace ForumSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;

    using static ForumSystem.Data.Common.DataValidation.CategoryValudation;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Url]
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        // This relation is one to many
        // One category have one creator (user) and one creator (user) can have many category
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public int CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        // One category can have many posts
        public virtual ICollection<Post> Posts { get; set; }
    }
}
