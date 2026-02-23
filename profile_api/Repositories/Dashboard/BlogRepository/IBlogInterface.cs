using profile_api.Models.Domain;

namespace profile_api.Repositories.Dashboard.BlogRepository
{
    public interface IBlogInterface
    {

        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog?> CreateAsync(Blog blog);
        Task<Blog?> UpdateAsync(int id, Blog blog);
        Task<Blog?> DeleteAsync(int id);
    }
}
