
namespace CodecoolMaterialsAPI.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int CredentialsId { get; set; }
        public Credentials Credentials { get; set; }
        public Role Role { get; set; }
    }
}
