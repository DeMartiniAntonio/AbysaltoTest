using AbySalto.Junior.Domain.Enums;

namespace AbySalto.Junior.Domain.Entities
{
    public class Order
    {
        public int orderId { get; set; }

        public string customerName { get; set; }
        public OrderStatus status { get; set; }
        public DateTime orderTime { get; set; }

        public PaymentMethod paymentMethod { get; set; }

        public string deliveryAddress { get; set; }
        public string contactNumber { get; set; }
        public string note { get; set; }

        public List<OrderArticle> OrderArticles  { get; set; } = new();
        
        public decimal totalAmount { get; set; }
        public string currency { get; set; }
    }
}