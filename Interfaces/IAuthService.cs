using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IAuthService
    {
        Task<User?> ValidateUser(string username, string password);
        Task<string?> RefreshToken(string refreshToken);
    }
}
