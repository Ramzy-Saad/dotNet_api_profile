using AutoMapper;
using profile_api.Models.Domain;
using profile_api.Models.DTO.Dashboard.Category;

namespace profile_api.Mappings
{
    public class AutoMappingProfiles:Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
        }
    }
}
