using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodecoolMaterialsAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _config = configuration;
        }

        public async Task<string> LoginAsync(string hashedLogin, string hashedPassword)
        {
            if (!await _unitOfWork.CredentialsRepository.AnyByCredentialsAsync(hashedLogin, hashedPassword))
                throw new ResourceNotFoundException($"Login or Password is incorect");
            User user = await _unitOfWork.UserRepository.GetUserByCredentialsAsync(hashedLogin, hashedPassword);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signIn); ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
