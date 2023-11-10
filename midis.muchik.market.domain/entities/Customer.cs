namespace midis.muchik.market.domain.entities
{
    public partial class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime BornedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
