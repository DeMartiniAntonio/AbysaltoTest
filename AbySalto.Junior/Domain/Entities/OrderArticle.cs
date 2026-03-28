namespace AbySalto.Junior.Domain.Entities
{
    public class OrderArticles
    {
        public int orderArticlesId { get; set; }

        public string name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

    }
}