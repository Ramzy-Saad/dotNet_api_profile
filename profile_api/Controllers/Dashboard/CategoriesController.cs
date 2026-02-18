using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profile_api.Data;
using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard.Category;
using System.Threading.Tasks;

namespace profile_api.Controllers.Dashboard
{

    // domain/api/dashboard/categories
    [Route("api/dashboard/[controller]")]
    public class CategoriesController : ControllerBase
    {
        protected AppDbContext dbcontext;
        public CategoriesController(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        // Get all Categories
        [HttpGet]
        public IActionResult GetAll()
        {
            var categroiesDto = dbcontext.Categories
               .Select(c => new CategoryDto
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToList();

            return Ok(categroiesDto);                
        }

        // Get category by Id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var category = dbcontext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = new CategoryDto()
            {
                Id=category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }

        // Create category
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var newCategory = new Category
            {
                Name = createCategoryDto.Name
            };
            dbcontext.Categories.Add(newCategory);
            await dbcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = newCategory.Id },
                newCategory);
        }

        // Update category
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] CreateCategoryDto createCategoryDto)
        {
            var category = await dbcontext.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            category.Name = createCategoryDto.Name;
            await dbcontext.SaveChangesAsync();
            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(categoryDto);
        }

        // Delete category
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await dbcontext.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            dbcontext.Categories.Remove(category);
            await dbcontext.SaveChangesAsync();
            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(categoryDto);
        }

    }
}
