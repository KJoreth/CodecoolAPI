namespace CodecoolMaterialsAPI.MapperProfiles
{
    public class MaterialProfiles : Profile
    {
        public MaterialProfiles()
        {
            CreateMap<Material, MaterialSimpleDTO>();

            CreateMap<Material, MaterialDetailedDTO>()
                .ForMember(dest => dest.PublishDate,
                opt => opt.MapFrom(src => src.PublishDate.ToString("dd-MMM-yyyy")))
                .ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<MaterialCreateUpdateDTO, Material>();
            CreateMap<Material, MaterialCreatedDTO>();
        }
    }
}
