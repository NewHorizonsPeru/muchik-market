namespace midis.muchik.market.application.dto
{
    public class ProductDto
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ProductSku { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; } = null!;
        public int ProductScore { get; set; }
        public int ProductStock { get; set; }
        public string CategoryId { get; set; } = null!;
        public string BrandId { get; set; } = null!;

        public BrandDto Brand { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
    }
}
