
namespace CodecoolMaterialsAPI.DTOs.MaterialDTOs
{
    public record MaterialCreateUpdateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int TypeId { get; set; }

    }
}
