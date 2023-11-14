namespace midis.muchik.market.application.dto
{
    public class ProductDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Score { get; set; }
        public int Stock { get; set; }

        public BrandDto Brand { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
    }
}
