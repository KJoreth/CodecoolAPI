namespace CodecoolMaterialsAPI.DTOs.MaterialDTOs
{
    public class MaterialCreatedDTO
    {
        public int Id { get; set; }
        public string Titile { get; set; }
        public string Location { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
    }
}
