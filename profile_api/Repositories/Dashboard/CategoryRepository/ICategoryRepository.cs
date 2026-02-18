using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard.Category;

namespace profile_api.Repositories.Dashboard.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> CreateAsync(Category category);
        Task<Category?> UpdateAsync(int id ,Category category);

        Task<Category?> DeleteAsync(int id);

    }
}
