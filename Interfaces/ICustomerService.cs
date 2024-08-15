using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerById(long id);
        Task<Customer> RegisterCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task DeleteCustomer(long customerId);
        Task<bool> IsEmailTaken(string email);
        Task<bool> IsUsernameTaken(string username);
        Task<List<Customer>> GetAllCustomers();
    }
}
