using QuickBitesBackend.Enum;
using QuickBitesBackend.Helpers;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;

namespace QuickBitesBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly TokenHelpers _tokenHelpers;

        public AuthService(ICustomerRepository customerRepository, IAdminRepository adminRepository,
                           IRefreshTokenRepository refreshTokenRepository, TokenHelpers tokenHelpers)
        {
            _customerRepository = customerRepository;
            _adminRepository = adminRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelpers = tokenHelpers;
        }

        // Validating user credentials (username and password)
        public async Task<User?> ValidateUser(string username, string password)
        {
            // Check if the user is a Customer or an Admin
            var customer = await _customerRepository.GetCustomerByUsername(username);
            var admin = await _adminRepository.GetAdminByUsername(username);

            // Combine user objects into a single User type
            User? user = customer ?? (User?)admin;

            // Validate password (password comparison logic; use hashing in production)
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }

        // Refreshing JWT token logic
        public async Task<string?> RefreshToken(string refreshToken)
        {
            // Get the refresh token from the repository
            var token = await _refreshTokenRepository.GetRefreshToken(refreshToken);
            if (token == null || token.ExpiresIn <= 0 || token.CreatedAt.AddMinutes(token.ExpiresIn) <= DateTime.UtcNow)
            {
                return null; // Token is expired or invalid
            }

            // Retrieve the user based on the stored refresh token
            var user = await _customerRepository.GetCustomerById(token.UserId) ??
                       (User?)await _adminRepository.GetAdminById(token.UserId);

            if (user == null)
            {
                return null;
            }

            // Generate a new JWT token using TokenHelpers
            return _tokenHelpers.GenerateJwtToken(user);
        }

        // Creating a new refresh token
        public async Task<RefreshToken> CreateRefreshToken(User user)
        {
            // Create a new refresh token with a 1-day expiration
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                ExpiresIn = 60 * 24, // Token expires in 1 day (1440 minutes)
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                UserType = user is Customer ? UserType.Customer : UserType.Admin
            };

            // Store the refresh token in the repository
            await _refreshTokenRepository.CreateRefreshToken(refreshToken);

            return refreshToken;
        }
    }
}
