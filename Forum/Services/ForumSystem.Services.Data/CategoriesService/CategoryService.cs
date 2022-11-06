namespace ForumSystem.Services.Data.CategoriesService
{
    using ForumSystem.Data;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
