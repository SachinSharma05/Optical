using api.Entities;

namespace api.Abstraction.Services
{
    public interface IAuthService
    {
        Task<User> ValidateUserAsync(string username, string password);
        string GenerateJwtToken(User user);
        Task<bool> RegisterUserAsync(Register user);
        Task<bool> ChangePasswordAsync(ChangePassword password, int id);
        Task<User> GetUserById(int id);
    }
}
