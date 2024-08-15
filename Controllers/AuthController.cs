using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using QuickBitesBackend.Helpers;
using QuickBitesBackend.Interfaces;
namespace QuickBitesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly TokenHelpers _tokenHelpers;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _tokenHelpers = new TokenHelpers(
                configuration["Jwt:Key"],
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"]
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _authService.ValidateUser(loginRequest.Username, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = _tokenHelpers.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var newToken = await _authService.RefreshToken(refreshTokenRequest.Token);
            if (newToken == null)
            {
                return Unauthorized("Invalid refresh token.");
            }

            return Ok(new { Token = newToken });
        }
    }
}
