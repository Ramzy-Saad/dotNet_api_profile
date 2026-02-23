using AutoMapper;
using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard.Blog;
using profile_api.Models.DTO.Dashboard.Category;

namespace profile_api.Mappings
{
    public class AutoMappingProfiles:Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();

            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<BlogDto, Blog>().ReverseMap();
        }
    }
}
