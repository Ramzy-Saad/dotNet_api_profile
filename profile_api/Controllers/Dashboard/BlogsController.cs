using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profile_api.Data;

namespace profile_api.Controllers.Dashboard
{
    [Route("api/dashboard/[controller]")]
    public class BlogsController : ControllerBase
    {
        protected AppDbContext dbcontext;
        public BlogsController(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            string[] blogsName = new string[] { "Blog1", "Blog2", "Blog3" };
            return Ok(blogsName);
        }
    }
}
