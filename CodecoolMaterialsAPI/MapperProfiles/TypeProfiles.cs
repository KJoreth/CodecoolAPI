
namespace CodecoolMaterialsAPI.MapperProfiles
{
    public class TypeProfiles : Profile
    {
        public TypeProfiles()
        {
            CreateMap<MaterialType, TypeSimpleDTO>();
            CreateMap<MaterialType, TypeDetailedDTO>();
        }
    }
}
