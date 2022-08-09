namespace CodecoolMaterialsAPI.DTOs.UserDTOs
{
    public class UserAuthorizationDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
