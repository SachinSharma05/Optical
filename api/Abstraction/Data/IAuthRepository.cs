using api.Entities;

namespace api.Abstraction.Data
{
    public interface IAuthRepository
    {
        Task<User> GetByUsernameAsync(string username, string password); // Fetch a user by username
        Task<bool> RegisterUserAsync(Register user); // Add a new user to the database
        Task<bool> ChangePasswordAsync(ChangePassword password, int id);
        Task<User> GetUserById(int id);
    }
}
