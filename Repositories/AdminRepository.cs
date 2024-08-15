using QuickBitesBackend.Data;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace QuickBitesBackend.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _dbContext;

        public AdminRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin?> GetAdminById(long id)
        {
            return await _dbContext.Admins.FindAsync(id);
        }

        public async Task<Admin> RegisterAdmin(Admin admin)
        {
            await _dbContext.Admins.AddAsync(admin);
            await _dbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            _dbContext.Admins.Update(admin);
            await _dbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _dbContext.Admins.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _dbContext.Admins.AnyAsync(x => x.Username == username);
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            return await _dbContext.Admins.ToListAsync();
        }

        public async Task DeleteAdmin(Admin admin)
        {
            _dbContext.Admins.Remove(admin);
            await _dbContext.SaveChangesAsync();
        }
    }
}
