
namespace CodecoolMaterialsAPI.MapperProfiles
{
    public class AdminProfiles : Profile
    {
        public AdminProfiles() 
        {
            CreateMap<User, UserSimpleDTO>();
        }
    }
}
