
namespace CodecoolMaterialsAPI.MapperProfiles
{
    public class ReviewProfiles : Profile
    {
        public ReviewProfiles()
        {
            CreateMap<Review, ReviewSimpleDTO>()
                .ForMember(dest => dest.Points,
                opt => opt.MapFrom(src => $"{src.Points} / 10"));
        }
    }
}
