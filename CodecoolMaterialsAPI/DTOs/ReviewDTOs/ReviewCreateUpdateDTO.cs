using System.ComponentModel.DataAnnotations;

namespace CodecoolMaterialsAPI.DTOs.ReviewDTOs
{
    public class ReviewCreateUpdateDTO
    {
        [Required]
        [Range(1, 10)]
        public int Points { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int MaterialId { get; set; }
    }
}
