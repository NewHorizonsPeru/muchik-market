namespace midis.muchik.market.domain.entities
{
    public partial class Order
    {
        public Order() { OrderDetail = new HashSet<OrderDetail>(); }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Correlative { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public int State { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
