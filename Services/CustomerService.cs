using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;
using QuickBitesBackend.Repositories;

namespace QuickBitesBackend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> GetCustomerById(long id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            if (await _customerRepository.IsEmailTaken(customer.Email))
            {
                throw new Exception("Email is already taken");
            }

            if (await _customerRepository.IsUsernameTaken(customer.Username))
            {
                throw new Exception("Username is already taken");
            }

            return await _customerRepository.RegisterCustomer(customer);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await _customerRepository.UpdateCustomer(customer);
        }

        public async Task DeleteCustomer(long customerId)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            await _customerRepository.DeleteCustomer(customer);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _customerRepository.IsEmailTaken(email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _customerRepository.IsUsernameTaken(username);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

    }
}
