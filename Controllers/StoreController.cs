using Microsoft.AspNetCore.Mvc;
using QuickBitesBackend.Models;

using QuickBitesBackend.Interfaces;
namespace QuickBitesBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Store>>> GetAllStores()
        {
            return Ok(await _storeService.GetAllStores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStoreById(long id)
        {
            var store = await _storeService.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(Store store)
        {
            var newStore = await _storeService.CreateStore(store);
            return CreatedAtAction(nameof(GetStoreById), new { id = newStore.Id }, newStore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(long id, Store store)
        {
            if (id != store.Id)
            {
                return BadRequest();
            }
            await _storeService.UpdateStore(store);
            return NoContent();
        }
    }
}
