using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profile_api.Data;
using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard.Blog;
using profile_api.Repositories.Dashboard.BlogRepository;

namespace profile_api.Controllers.Dashboard
{
    [Route("api/dashboard/[controller]")]
    public class BlogsController : ControllerBase
    {
        protected IMapper mapper;
        private readonly IBlogInterface blogInterface;

        public BlogsController(IMapper mapper, IBlogInterface blogInterface)
        {
            this.mapper = mapper;
            this.blogInterface = blogInterface;
        }
         
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await blogInterface.GetAllAsync();
            return Ok(mapper.Map<List<BlogDto>>(blogs));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogDto createBlogDto)
        {
            var BlogDomain = mapper.Map<Blog>(createBlogDto);

            await blogInterface.CreateAsync(BlogDomain);
            return Ok(mapper.Map<BlogDto>(BlogDomain));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var BlogDomain = await blogInterface.GetByIdAsync(id);
            if (BlogDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BlogDto>(BlogDomain));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateBlogDto createBlogDto)
        {
            var BlogDomain = mapper.Map<Blog>(createBlogDto);
            var blog = await blogInterface.UpdateAsync(id, BlogDomain);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BlogDto>(blog));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var blogDomain = await blogInterface.DeleteAsync(id);
            if(blogDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BlogDto>(blogDomain));
        }


    }
}
