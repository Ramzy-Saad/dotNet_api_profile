using profile_api.Data;
using profile_api.Models.Domain;

namespace profile_api.Repositories.Dashboard.BlogRepository
{
    public class SqlBlogRepository : IBlogInterface
    {
        private readonly AppDbContext dbContext;

        public SqlBlogRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Blog?> CreateAsync(Blog blog)
        {
            await dbContext.AddAsync<Blog>(blog);
            await dbContext.SaveChangesAsync();
            return blog;
        }

        public Task<Blog?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Blog?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Blog?> UpdateAsync(int id, Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
