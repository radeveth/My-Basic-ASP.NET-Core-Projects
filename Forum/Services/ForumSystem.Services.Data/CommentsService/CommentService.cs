namespace ForumSystem.Services.Data.CommentsService
{
    using ForumSystem.Data;

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
