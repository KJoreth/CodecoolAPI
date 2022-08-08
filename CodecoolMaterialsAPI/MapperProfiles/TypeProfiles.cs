
namespace CodecoolMaterialsAPI.MapperProfiles
{
    public class TypeProfiles : Profile
    {
        public TypeProfiles()
        {
            CreateMap<Data.Entities.Type, TypeSimpleDTO>();
        }
    }
}
