namespace midis.muchik.market.application.dto.omnichannel
{
    public class AddOrderDto
    {
        public string Correlative { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public int State { get; set; } = 1;
        public decimal Total { get; set; }

        public ICollection<AddOrderDetailDto> OrderDetail { get; set; } = null!;
    }

    public class AddOrderDetailDto
    {
        public string ProductId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
