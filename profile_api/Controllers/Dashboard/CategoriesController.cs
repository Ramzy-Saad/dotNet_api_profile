
using Microsoft.AspNetCore.Mvc;
using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard.Category;
using profile_api.Repositories.Dashboard.CategoryRepository;

namespace profile_api.Controllers.Dashboard
{

    // domain/api/dashboard/categories
    [Route("api/dashboard/[controller]")]
    public class CategoriesController : ControllerBase
    {
        protected ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Get all Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoriesDto = (await _categoryRepository.GetAllAsync())
               .Select(c => new CategoryDto { Id = c.Id, Name = c.Name })
               .ToList();

            return Ok(categoriesDto);              
        }

        // Get category by Id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
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
            await _categoryRepository.CreateAsync(newCategory);

            return CreatedAtAction(nameof(GetById),
                new { id = newCategory.Id },
                newCategory);
        }

        // Update category
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] CreateCategoryDto createCategoryDto)
        {
            var categoryDomain = new Category { Name = createCategoryDto.Name };
            var category = await _categoryRepository.UpdateAsync(id, categoryDomain);

            if (category == null)
                return NotFound();

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
            var category = await _categoryRepository.DeleteAsync(id);
            if (category == null)
                return NotFound();

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(categoryDto);
        }

    }
}
