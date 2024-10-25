using api.Abstraction;
using api.Data;
using api.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext applicationDbContext, IConfiguration config, IAuthRepository authRepository) 
        {
            _context = applicationDbContext;
            _authRepository = authRepository;
            _config = config;
        }

        public async Task<bool> ChangePasswordAsync(ChangePassword password, int id)
        {
            bool response = await _authRepository.ChangePasswordAsync(password, id);
            if (response == false) return false;

            return true; // Successfully changed password
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _authRepository.GetUserById(id);
            if (user == null) return null;

            return user;
        }

        public async Task<bool> RegisterUserAsync(Register user)
        {
            bool response = await _authRepository.RegisterUserAsync(user);
            if (response == false) return false;

            return true; // Successfully registered
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var user = await _authRepository.GetByUsernameAsync(username, password);
            if (user == null) return null;

            return user;
        }
    }
}
