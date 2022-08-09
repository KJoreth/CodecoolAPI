
namespace CodecoolMaterialsAPI.DTOs.MaterialDTOs
{
    public record MaterialDetailedDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string PublishDate { get; set; }
        public string Author { get; set; }
        public TypeSimpleDTO Type { get; set; }
        public List<ReviewSimpleDTO> Reviews { get; set; } = new List<ReviewSimpleDTO>();
    }
}
