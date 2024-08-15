using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IPartnerRepository
    {
        Task<List<Partner>> GetAllPartners();
        Task<List<Partner>> GetPartnersByStatus(PartnerStatus status);
        Task<Partner?> GetPartnerById(long id);
        Task<Partner> RegisterPartner(Partner partner);
        Task<Partner> UpdatePartner(Partner partner);
        Task DeletePartner(Partner partner);
        Task<bool> IsEmailTaken(string email);  // New method
        Task<bool> IsUsernameTaken(string username);
    }
}
