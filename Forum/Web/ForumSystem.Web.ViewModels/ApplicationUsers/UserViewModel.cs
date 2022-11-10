namespace ForumSystem.Web.ViewModels.ApplicationUsers
{
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
