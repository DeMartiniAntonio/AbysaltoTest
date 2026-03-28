using AbySalto.Junior.Domain.Enums;
using AbySalto.Junior.Domain.Entities;
using AbySalto.Junior.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AbySalto.Junior.Services 
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _context;

        public OrderService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            order.OrderTime = DateTime.UtcNow;
            order.Status = OrderStatus.Pending;
            order.RecalculateTotalAmount();

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(order => order.OrderArticles)
                .ToListAsync();
        }
        
        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null) return false;
            order.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Order>> GetOrdersSortedByAmountAsync()
        {
            return await _context.Orders
                .Include(order => order.OrderArticles)
                .OrderByDescending(order => order.TotalAmount)
                .ToListAsync();
        }
    }

}