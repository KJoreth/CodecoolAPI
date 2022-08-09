namespace CodecoolMaterialsAPI.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserSimpleDTO> CreateNewAsync(string login, string password)
        {
            var hashedLogin = Hasher.ComputeSha256Hash(login);
            var hashedPassword = Hasher.ComputeSha256Hash(password);
            if (await _unitOfWork.UserRepository.AnyByLoginAsync(hashedLogin))
                throw new ResourceAlreadyExistsException($"Login {login} is already taken");
            User admin = new User() { Role = Role.Admin };
            Credentials credentials = new Credentials() { Login = hashedLogin, Password = hashedPassword };
            admin.Credentials = credentials;
            await _unitOfWork.UserRepository.AddAsync(admin);
            await _unitOfWork.CompleteUnitAsync();
            return new UserSimpleDTO() { Id = admin.Id, Login = login, Role = Role.Admin.ToString() };
        }
    }
}
