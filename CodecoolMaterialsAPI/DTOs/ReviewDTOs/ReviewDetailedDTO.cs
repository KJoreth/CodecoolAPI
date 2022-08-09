namespace CodecoolMaterialsAPI.DTOs.ReviewDTOs
{
    public record ReviewDetailedDTO
    {
        public int Id { get; set; }
        public string Points { get; set; }
        public string Text { get; set; }
    }
}
