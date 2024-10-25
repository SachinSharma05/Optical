using api.Abstraction;
using api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _authService.ValidateUserAsync(login.Username, login.Password);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            // Generate JWT token (optional)
            var token = _authService.GenerateJwtToken(user);

            return Ok(
                new
                {
                    Token = token,
                    Username = user.UserName
                }
            );
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterUserAsync(registerUser);

            if (!result)
                return BadRequest("User with the same email or username already exists");

            return Ok("User registered successfully");
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword password, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ChangePasswordAsync(password, id);

            if (!result)
                return BadRequest("Unable to change password at the moment");

            return Ok("User registered successfully");
        }

        [HttpGet("user-profile")]
        public async Task<IActionResult> UserProfile(int id)
        {
            if (id == null)
                return BadRequest("UserID is null");

            var result = await _authService.GetUserById(id);

            if (result == null)
                return BadRequest("User doesn't exists");

            return Ok(result);
        }
    }
}
