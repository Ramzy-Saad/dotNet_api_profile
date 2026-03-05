using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Blog>> GetAllAsync()
        {
            var blogs = await dbContext.Blogs.Include("Category").ToListAsync();
            return blogs;
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await dbContext.Blogs.Include("Category").FirstOrDefaultAsync(x => x.Id== id);
        }

        public async Task<Blog?> UpdateAsync(int id, Blog blog)
        {
            var blogDomain = await dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (blogDomain == null)
            {
                return null;
            }
            blogDomain.Status = blog.Status;
            blogDomain.Name = blog.Name;
            blogDomain.Description = blog.Description;
            blogDomain.Slug = blog.Slug;
            blogDomain.CategoryId = blog.CategoryId;
            blogDomain.Image = blog.Image;
            await dbContext.SaveChangesAsync();
            return blogDomain;
        }


        public async Task<Blog?> DeleteAsync(int id)
        {
            var blogDomain = await dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (blogDomain == null)
            {
                return null;
            }
            dbContext.Blogs.Remove(blogDomain);
            await dbContext.SaveChangesAsync();
            return blogDomain;
        }
    }

}
