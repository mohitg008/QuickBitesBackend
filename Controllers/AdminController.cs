using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;

namespace QuickBitesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Ensures only admins can access this controller
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // Get all admins
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdmins();
            return Ok(admins);
        }

        // Get admin by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(long id)
        {
            var admin = await _adminService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        // Create new admin
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Admin admin)
        {
            var newAdmin = await _adminService.RegisterAdmin(admin);
            return CreatedAtAction(nameof(GetAdminById), new { id = newAdmin.Id }, newAdmin);
        }

        // Update an existing admin
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(long id, [FromBody] Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            await _adminService.UpdateAdmin(admin);
            return NoContent();
        }

        // Delete admin
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(long id)
        {
            var admin = await _adminService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }

            await _adminService.DeleteAdmin(id);
            return NoContent();
        }
    }
}
