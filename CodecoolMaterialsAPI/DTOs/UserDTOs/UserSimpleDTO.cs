namespace CodecoolMaterialsAPI.DTOs.UserDTOs
{
    public record UserSimpleDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
    }
}
