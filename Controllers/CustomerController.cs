using Microsoft.AspNetCore.Mvc;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;

namespace QuickBitesBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return Ok(await _customerService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(long id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer(Customer customer)
        {
            var newCustomer = await _customerService.RegisterCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            await _customerService.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            await _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
