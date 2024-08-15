using Microsoft.AspNetCore.Mvc;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;

namespace QuickBitesBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(long id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var newOrder = await _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, newOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(long id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            await _orderService.UpdateOrder(order);
            return NoContent();
        }
    }
}
