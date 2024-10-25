using api.Abstraction;
using api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace api.Data.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthRepository(ApplicationDbContext applicationDbContext, IPasswordHasher<User> passwordHasher) 
        {
            _context = applicationDbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterUserAsync(Register regUser)
        {
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == regUser.Email || u.UserName == regUser.Username))
                {
                    return false; // User already exists
                }

                var salt = GenerateSalt();
                // Create a new User entity
                var user = new User
                {
                    UserName = regUser.Username,
                    Email = regUser.Email,
                    Salt = salt,
                    CreatedDate = DateTime.UtcNow
                };

                // Hash the password
                user.PasswordHash = HashPassword(regUser.Password, salt);

                // Add and save the user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByUsernameAsync(string username, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
                if (user == null)
                {
                    return null;
                }

                var hashedPassword = HashPassword(password, user.Salt);
                if (user.PasswordHash != hashedPassword)
                {
                    return null;
                }

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ChangePasswordAsync(ChangePassword password, int id)
        {
            try
            {
                var user = await GetUserById(id);
                if (user == null)
                {
                    return false;
                }

                var salt = GenerateSalt();

                user.Salt = salt;
                user.PasswordHash = HashPassword(password.NewPassword, salt);

                // Add and save the user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (user == null)
                {
                    return null;
                }

                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #region Private Method
        private string GenerateSalt()
        {
            try
            {
                byte[] saltBytes = new byte[16];
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    rng.GetBytes(saltBytes);
                }
                return Convert.ToBase64String(saltBytes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string HashPassword(string password, string salt)
        {
            try
            {
                var combinedPassword = password + salt;
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));
                    return Convert.ToBase64String(hashedBytes);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
