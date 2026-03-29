using AbySalto.Junior.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Cloud.Firestore;

namespace AbySalto.Junior.Domain.Entities
{
    [FirestoreData]
    public class Order
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;

        [FirestoreProperty]
        public string CustomerName { get; set; } = string.Empty;

        [FirestoreProperty]
        public OrderStatus Status { get; set; }

        [FirestoreProperty]
        public DateTime OrderTime { get; set; }

        [FirestoreProperty]
        public PaymentMethod PaymentMethod { get; set; }

        [FirestoreProperty]
        public string DeliveryAddress { get; set; } = string.Empty;

        [FirestoreProperty]
        public string ContactNumber { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Note { get; set; } = string.Empty;

        [FirestoreProperty]
        public List<OrderArticle> OrderArticles { get; set; } = new();

        [FirestoreProperty]
        public double TotalAmount { get; set; }

        [FirestoreProperty]
        public string Currency { get; set; } = string.Empty;

        public void RecalculateTotalAmount()
        {
            TotalAmount = OrderArticles.Sum(a => a.Price * a.Quantity);
        }
    }
}