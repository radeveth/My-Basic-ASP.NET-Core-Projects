namespace ForumSystem.Services.Data.CategoriesService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data;
    using ForumSystem.Data.Models;
    using ForumSystem.InputModels.Categories;
    using ForumSystem.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CategoryFormModel categoryForm)
        {
            Category category = new Category()
            {
                Name = categoryForm.Name,
                Description = categoryForm.Description,
                ImageUrl = categoryForm.ImageUrl,
                CreatorId = categoryForm.CreatorId,
            };

            await this.dbContext.Categories.AddAsync(category);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.dbContext
                .Categories
                .To<T>();
        }

        public async Task<T> GetById<T>(int id)
        {
            return await this.dbContext
                .Categories
                .Where(c => c.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int id, CategoryFormModel categoryForm)
        {
            Category category = await this.dbContext
                .Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            try
            {
                category.Name = categoryForm.Name;
                category.Description = categoryForm.Description;
                category.ImageUrl = categoryForm.ImageUrl;

                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task DeleteAsync(int id)
        {
            Category category = await this.dbContext
                .Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            try
            {
                category.IsDeleted = true;
                category.DeletedOn = DateTime.UtcNow;

                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
