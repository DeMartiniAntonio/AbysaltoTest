using AbySalto.Junior.Domain.Entities;
using AbySalto.Junior.Domain.Enums;
using Google.Cloud.Firestore;

namespace AbySalto.Junior.Services
{
    public class OrderService : IOrderService
    {
        private readonly FirestoreDb _firestore;
        private readonly string _collection = "orders";

        public OrderService(FirestoreDb firestore)
        {
            _firestore = firestore;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            order.OrderTime = DateTime.UtcNow;
            order.Status = OrderStatus.Pending;
            order.RecalculateTotalAmount();

            var docRef = await _firestore
                .Collection(_collection)
                .AddAsync(order);

            order.Id = docRef.Id;

            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var snapshot = await _firestore
                .Collection(_collection)
                .GetSnapshotAsync();

            return snapshot.Documents
                .Select(doc =>
                {
                    var order = doc.ConvertTo<Order>();
                    order.Id = doc.Id;
                    return order;
                })
                .ToList();
        }

        public async Task<bool> UpdateOrderStatusAsync(string orderId, OrderStatus status)
        {
            var snapshot = await _firestore
                .Collection(_collection)
                .GetSnapshotAsync();

            var doc = snapshot.Documents.FirstOrDefault(d =>
            {
                var o = d.ConvertTo<Order>();
                return o.Id == orderId;
            });

            if (doc == null) return false;

            await doc.Reference.UpdateAsync("Status", status);
            return true;
        }

        public async Task<List<Order>> GetOrdersSortedByAmountAsync()
        {
            var snapshot = await _firestore
                .Collection(_collection)
                .OrderByDescending("TotalAmount")
                .GetSnapshotAsync();

            return snapshot.Documents
                .Select(doc => doc.ConvertTo<Order>())
                .ToList();
        }
    }
}