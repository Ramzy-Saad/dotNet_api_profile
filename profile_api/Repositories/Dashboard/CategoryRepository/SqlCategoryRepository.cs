using Microsoft.EntityFrameworkCore;
using profile_api.Data;
using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard.Category;

namespace profile_api.Repositories.Dashboard.CategoryRepository
{

    public class SqlCategoryRepository: ICategoryRepository
    {
        protected readonly AppDbContext dbContext;
        public SqlCategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await dbContext.Categories.FindAsync(id);
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category?> UpdateAsync(int id , Category category)
        {
            var existCategory = await dbContext.Categories.FindAsync(id);
            if (existCategory == null)
                return null;
            existCategory.Name = category.Name;
            await dbContext.SaveChangesAsync();
            return existCategory;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var existCategory = await dbContext.Categories.FindAsync(id);
            if(existCategory == null)
                return null;
            dbContext.Categories.Remove(existCategory);
            await dbContext.SaveChangesAsync();
            return existCategory;

        }
    }
}
