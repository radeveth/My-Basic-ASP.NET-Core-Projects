namespace ForumSystem.Web.ViewModels.Comments
{
    using System.Linq;

    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Data.Models.Enums;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels.ApplicationUsers;
    using ForumSystem.Web.ViewModels.Posts;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public PostViewModel Post { get; set; }

        public UserViewModel User { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Likes, y => y.MapFrom(s => s.VoteComments.Where(v => v.Vote == VoteType.Like)))
                .ForMember(x => x.Dislikes, y => y.MapFrom(s => s.VoteComments.Where(v => v.Vote == VoteType.Dislike)));
        }
    }
}
