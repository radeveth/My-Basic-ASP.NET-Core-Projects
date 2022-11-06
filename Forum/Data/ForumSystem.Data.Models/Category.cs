namespace ForumSystem.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ForumSystem.Data.Common.Models;

    using static ForumSystem.Data.Common.DataValidation.CategoryValudation;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Url]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        // One category can have many posts
        public virtual ICollection<Post> Posts { get; set; }
    }
}
