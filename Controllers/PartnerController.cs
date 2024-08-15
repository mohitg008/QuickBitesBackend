using Microsoft.AspNetCore.Mvc;
using QuickBitesBackend.Models;
using QuickBitesBackend.Interfaces;

namespace QuickBitesBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Partner>>> GetAllPartners()
        {
            return Ok(await _partnerService.GetAllPartners());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> GetPartnerById(long id)
        {
            var partner = await _partnerService.GetPartnerById(id);
            if (partner == null)
            {
                return NotFound();
            }
            return Ok(partner);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPartner(Partner partner)
        {
            var newPartner = await _partnerService.RegisterPartner(partner);
            return CreatedAtAction(nameof(GetPartnerById), new { id = newPartner.Id }, newPartner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartner(long id, Partner partner)
        {
            if (id != partner.Id)
            {
                return BadRequest();
            }
            await _partnerService.UpdatePartner(partner);
            return NoContent();
        }
    }
}
