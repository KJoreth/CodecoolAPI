namespace CodecoolMaterialsAPI.MapperProfiles
{
    public class MaterialProfiles : Profile
    {
        public MaterialProfiles()
        {
            CreateMap<Material, MaterialSimpleDTO>();
        }
    }
}
