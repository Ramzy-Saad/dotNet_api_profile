namespace profile_api.Models.DTO.Dashboard.Blog
{
    public class CreateBlogDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public Boolean Status { get; set; }
        public int? CategoryId { get; set; }

    }
}
