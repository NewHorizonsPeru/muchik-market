namespace midis.muchik.market.application.dto.common
{
    public class AddProductDto
    {
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Score { get; set; }
        public int Stock { get; set; }
        public string CategoryId { get; set; } = null!;
        public string BrandId { get; set; } = null!;
    }
}
