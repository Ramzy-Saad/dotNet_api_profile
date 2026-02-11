using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace profile_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            string[] blogsName = new string[] { "Blog1", "Blog2", "Blog3" };
            return Ok(blogsName);
        }
    }
}
