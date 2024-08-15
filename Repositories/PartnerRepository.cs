using QuickBitesBackend.Data;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace QuickBitesBackend.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly AppDbContext _dbContext;

        public PartnerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Partner>> GetAllPartners()
        {
            return await _dbContext.Partners.ToListAsync();
        }

        public async Task<List<Partner>> GetPartnersByStatus(PartnerStatus status)
        {
            return await _dbContext.Partners.Where(p => p.Status == status).ToListAsync();
        }

        public async Task<Partner?> GetPartnerById(long id)
        {
            return await _dbContext.Partners.FindAsync(id);
        }

        public async Task<Partner> RegisterPartner(Partner partner)
        {
            await _dbContext.Partners.AddAsync(partner);
            await _dbContext.SaveChangesAsync();
            return partner;
        }

        public async Task<Partner> UpdatePartner(Partner partner)
        {
            _dbContext.Partners.Update(partner);
            await _dbContext.SaveChangesAsync();
            return partner;
        }

        public async Task DeletePartner(Partner partner)
        {
            _dbContext.Partners.Remove(partner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _dbContext.Partners.AnyAsync(p => p.Email == email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _dbContext.Partners.AnyAsync(p => p.Username == username);
        }
    }
}
