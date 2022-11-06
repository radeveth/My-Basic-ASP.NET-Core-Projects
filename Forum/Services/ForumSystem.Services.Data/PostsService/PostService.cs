namespace ForumSystem.Services.Data.PostsService
{
    using ForumSystem.Data;

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
