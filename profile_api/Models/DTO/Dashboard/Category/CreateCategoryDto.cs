using System.ComponentModel.DataAnnotations;

namespace profile_api.Models.DTO.Dashboard.Category
{
    public class CreateCategoryDto
    {
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
