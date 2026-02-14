using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profile_api.Data;
using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard;

namespace profile_api.Controllers.Dashboard
{
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
    }

}
