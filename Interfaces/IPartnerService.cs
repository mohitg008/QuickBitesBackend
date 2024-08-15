using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IPartnerService
    {
        Task<Partner?> GetPartnerById(long id);

        Task<Partner> RegisterPartner(Partner partner);

        Task<Partner> UpdatePartner(Partner partner);

        Task DeletePartner(long partnerId);
        Task<bool> IsEmailTaken(string email);
        Task<bool> IsUsernameTaken(string username);

        Task<List<Partner>> GetAllPartners();

        Task<List<Partner>> GetPartnersByStatus(PartnerStatus status);
    }
}
