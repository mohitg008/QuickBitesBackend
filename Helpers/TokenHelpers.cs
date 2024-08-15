using Microsoft.IdentityModel.Tokens;
using QuickBitesBackend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickBitesBackend.Helpers
{
    public class TokenHelpers
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenHelpers(string key, string issuer, string audience)
        {
            _key = key;
            _issuer = issuer;
            _audience = audience;
        }

        // Method to generate JWT Token
        public string GenerateJwtToken(User user)
        {
            // Convert the secret key to a byte array
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define claims for the token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username), // Sub claim for username
                new Claim(JwtRegisteredClaimNames.Email, user.Email), // Email claim
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique identifier for the token
                new Claim(ClaimTypes.Role, user is Admin ? "Admin" : "Customer") // Role claim based on user type
            };

            // Generate the JWT token
            var token = new JwtSecurityToken(
                _issuer, // Issuer from configuration
                _audience, // Audience from configuration
                claims, // Claims associated with the token
                expires: DateTime.Now.AddMinutes(30), // Token expiration time
                signingCredentials: credentials // Signing credentials using the secret key
            );

            // Return the serialized token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
