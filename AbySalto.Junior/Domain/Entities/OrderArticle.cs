using System.ComponentModel.DataAnnotations.Schema;


namespace AbySalto.Junior.Domain.Entities
{
    public class OrderArticle
    {
        public int OrderArticleId { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public required Order Order { get; set; }
    }
}