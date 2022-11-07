namespace ForumSystem.Services.Data.CategoriesService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ForumSystem.InputModels.Categories;

    public interface ICategoryService
    {
        public Task CreateAsync(CategoryFormModel categoryForm);

        public IEnumerable<T> GetAll<T>();

        public Task<T> GetById<T>(int id);

        public Task UpdateAsync(int id, CategoryFormModel categoryForm);

        public Task DeleteAsync(int id);
    }
}
