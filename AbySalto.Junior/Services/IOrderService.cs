using AbySalto.Junior.Domain.Entities;
using AbySalto.Junior.Domain.Enums;

namespace AbySalto.Junior.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetAllOrdersAsync();
        Task<bool> UpdateOrderStatusAsync(string orderId, OrderStatus status);
        Task<List<Order>> GetOrdersSortedByAmountAsync();
    }
}