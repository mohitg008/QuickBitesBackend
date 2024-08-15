using QuickBitesBackend.Data;
using QuickBitesBackend.Models;

using Microsoft.EntityFrameworkCore;
using QuickBitesBackend.Interfaces;


namespace QuickBitesBackend.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(long id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _context.Customers.AnyAsync(c => c.Username == username);
        }
    }
}
