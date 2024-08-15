using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;

namespace QuickBitesBackend.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<Partner?> GetPartnerById(long id)
        {
            return await _partnerRepository.GetPartnerById(id);
        }

        public async Task<Partner> RegisterPartner(Partner partner)
        {
            // Check if email or username is taken
            if (await _partnerRepository.IsEmailTaken(partner.Email))
            {
                throw new Exception("Email is already taken.");
            }

            if (await _partnerRepository.IsUsernameTaken(partner.Username))
            {
                throw new Exception("Username is already taken.");
            }

            return await _partnerRepository.RegisterPartner(partner);
        }

        public async Task<Partner> UpdatePartner(Partner partner)
        {
            return await _partnerRepository.UpdatePartner(partner);
        }

        public async Task DeletePartner(long partnerId)
        {
            var partner = await _partnerRepository.GetPartnerById(partnerId);
            if (partner == null)
            {
                throw new Exception("Partner not found.");
            }

            await _partnerRepository.DeletePartner(partner);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _partnerRepository.IsEmailTaken(email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _partnerRepository.IsUsernameTaken(username);
        }

        public async Task<List<Partner>> GetAllPartners()
        {
            return await _partnerRepository.GetAllPartners();
        }

        public async Task<List<Partner>> GetPartnersByStatus(PartnerStatus status)
        {
            return await _partnerRepository.GetPartnersByStatus(status);
        }
    }
}
