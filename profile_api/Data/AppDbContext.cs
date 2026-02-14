using Microsoft.EntityFrameworkCore;
using profile_api.Models.Domain;
using System.Reflection.Metadata;

namespace profile_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
