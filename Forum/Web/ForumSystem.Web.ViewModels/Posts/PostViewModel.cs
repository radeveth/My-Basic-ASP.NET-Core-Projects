namespace ForumSystem.Web.ViewModels.Posts
{
    using System.Linq;

    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Data.Models.Enums;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels.ApplicationUsers;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Likes, y => y.MapFrom(s => s.VotePosts.Where(v => v.Vote == VoteType.Like)))
                .ForMember(x => x.Dislikes, y => y.MapFrom(s => s.VotePosts.Where(v => v.Vote == VoteType.Dislike)));
        }
    }
}
