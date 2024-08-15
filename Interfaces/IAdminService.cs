using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IAdminService
    {
        Task<Admin?> GetAdminById(long id);
        Task<Admin> RegisterAdmin(Admin admin);
        Task<Admin> UpdateAdmin(Admin admin);
        Task<bool> IsEmailTaken(string email);
        Task<bool> IsUsernameTaken(string username);

        Task<List<Admin>> GetAllAdmins();

        Task DeleteAdmin(long adminId);
    }
}
