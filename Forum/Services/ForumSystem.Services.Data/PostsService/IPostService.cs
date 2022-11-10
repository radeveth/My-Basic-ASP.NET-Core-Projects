namespace ForumSystem.Services.Data.PostsService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ForumSystem.InputModels.Categories;
    using ForumSystem.InputModels.Posts;

    public interface IPostService
    {
        public Task CreateAsync(PostFormModel postForm);

        public IEnumerable<T> GetAll<T>();

        public Task<T> GetById<T>(int id);

        public Task UpdateAsync(int id, PostFormModel postForm);

        public Task DeleteAsync(int id);
    }
}
