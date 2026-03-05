using profile_api.Models.DTO.Dashboard.Category;

namespace profile_api.Models.DTO.Dashboard.Blog
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public Boolean Status { get; set; }
        public int? CategoryId { get; set; }

        public CategoryDto? Category { get; set; }

    }
}
