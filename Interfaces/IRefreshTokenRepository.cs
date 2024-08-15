using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetRefreshToken(string token);
        Task CreateRefreshToken(RefreshToken refreshToken);
        Task DeleteRefreshToken(RefreshToken refreshToken);
    }
}
