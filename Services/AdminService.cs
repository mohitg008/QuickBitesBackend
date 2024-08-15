using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;

namespace QuickBitesBackend.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin?> GetAdminById(long id)
        {
            return await _adminRepository.GetAdminById(id);
        }

        public async Task<Admin> RegisterAdmin(Admin admin)
        {
            if (await _adminRepository.IsEmailTaken(admin.Email))
            {
                throw new Exception("Email is already taken");
            }

            if (await _adminRepository.IsUsernameTaken(admin.Username))
            {
                throw new Exception("Username is already taken");
            }

            return await _adminRepository.RegisterAdmin(admin);
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            return await _adminRepository.UpdateAdmin(admin);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _adminRepository.IsEmailTaken(email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _adminRepository.IsUsernameTaken(username);
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            return await _adminRepository.GetAllAdmins();
        }

        public async Task DeleteAdmin(long adminId)
        {
            var admin = await _adminRepository.GetAdminById(adminId);
            if (admin == null)
            {
                throw new Exception("Admin not found");
            }

            await _adminRepository.DeleteAdmin(admin);
        }
    }
}
