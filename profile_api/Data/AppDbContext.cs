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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed Categories

            var categories = new List<Category>()
            {
                new Category(){ Id=1,Name = "Catgeory1" },
                new Category(){ Id=2,Name = "Catgeory2" },
                new Category(){ Id=3,Name = "Catgeory3" },
            };
            modelBuilder.Entity<Category>().HasData(categories);

        }
    }
}
