﻿// ReSharper disable VirtualMemberCallInConstructor
namespace ForumSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    using ForumSystem.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
            this.Categories = new HashSet<Category>();
            this.Notifications = new HashSet<Notification>();
        }

        public string FullName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        // One User can have many posts and one post have one user
        public virtual ICollection<Post> Posts { get; set; }

        // One User can have many comments and one comment have one user
        public virtual ICollection<Comment> Comments { get; set; }

        // One User can have many categories and one category have one user
        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
