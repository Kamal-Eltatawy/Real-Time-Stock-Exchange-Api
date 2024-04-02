using Domain.DTO;

namespace ApplicationService.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<AuthModel> RegisterAsync(RegisterModel registerModel);
        Task<LoginResponse> LoginAsync(LoginModel loginModel);
    }
}
