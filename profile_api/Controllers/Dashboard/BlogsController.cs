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
        public IActionResult GetAllBlogs()
        {
            string[] blogsName = new string[] { "Blog1", "Blog2", "Blog3" };
            return Ok(blogsName);
        }

         
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogDto createBlogDto)
        {
            var BlogDomain = mapper.Map<Blog>(createBlogDto);
            await blogInterface.CreateAsync(BlogDomain);
            return Ok(mapper.Map<BlogDto>(BlogDomain));
        }
    }
}
