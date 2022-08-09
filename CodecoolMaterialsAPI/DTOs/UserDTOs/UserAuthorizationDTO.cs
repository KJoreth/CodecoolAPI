namespace CodecoolMaterialsAPI.DTOs.UserDTOs
{
    public record UserAuthorizationDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
