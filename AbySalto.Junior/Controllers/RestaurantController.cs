using Microsoft.AspNetCore.Mvc;
using AbySalto.Junior.Domain.Entities;
using AbySalto.Junior.Domain.Enums;
using AbySalto.Junior.Services;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IOrderService _orderService;
        public RestaurantController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var createdOrder = await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetAllOrders), new { id = createdOrder.OrderId }, createdOrder);
        }
        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpPut("orders/{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderStatus status)
        {
            var success = await _orderService.UpdateOrderStatusAsync(id, status);

            if (!success)
                return NotFound();

            return NoContent();
        }
        [HttpGet("orders/sorted")]
        public async Task<IActionResult> GetOrdersSortedByAmount()
        {
            var orders = await _orderService.GetOrdersSortedByAmountAsync();
            return Ok(orders);
        }
    }
}
