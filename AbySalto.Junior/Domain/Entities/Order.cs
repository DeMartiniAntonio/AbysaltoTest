using AbySalto.Junior.Domain.Enums;

namespace AbySalto.Junior.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public DateTime OrderTime { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string DeliveryAddress { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public List<OrderArticle> OrderArticles { get; set; } = new();

        public decimal TotalAmount { get; private set; }
        public string Currency { get; set; } = string.Empty;

        public void RecalculateTotalAmount()
        {
            TotalAmount = OrderArticles.Sum(article => article.Price * article.Quantity);
        }
    }
}