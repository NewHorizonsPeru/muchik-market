namespace midis.muchik.market.domain.entities
{
    public partial class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Score { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CategoryId { get; set; } = null!;
        public string BrandId { get; set; } = null!;

        public virtual Brand Brand { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
