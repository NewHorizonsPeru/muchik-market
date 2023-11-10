namespace midis.muchik.market.application.dto
{
    public class CustomerDto
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime BornedAt { get; set; }
    }
}
