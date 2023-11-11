namespace midis.muchik.market.application.dto
{
    public class OrderDto
    {
        public string Id { get; set; } = null!;
        public string Correlative { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public int State { get; set; } = 1;
        public decimal Total { get; set; }

        public ICollection<OrderDetailDto> OrderDetail { get; set; } = null!;
    }
}
