using System.ComponentModel.DataAnnotations.Schema;
using Google.Cloud.Firestore;


namespace AbySalto.Junior.Domain.Entities
{
    [FirestoreData]
    public class OrderArticle
    {
        [FirestoreProperty]
        public string Name { get; set; } = string.Empty;

        [FirestoreProperty]
        public int Quantity { get; set; }

        [FirestoreProperty]
        public double Price { get; set; }
    }
}