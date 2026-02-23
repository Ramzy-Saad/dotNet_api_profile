
using AutoMapper;
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

        public IMapper mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        // Get all Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);

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

            return Ok(mapper.Map<CategoryDto>(category));
        }

        // Create category
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var newCategory = mapper.Map<Category>(createCategoryDto);
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

            return Ok(mapper.Map<CategoryDto>(category));
        }

        // Delete category
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _categoryRepository.DeleteAsync(id);
            if (category == null)
                return NotFound();
            return Ok(mapper.Map<CategoryDto>(category));
        }

    }
}
