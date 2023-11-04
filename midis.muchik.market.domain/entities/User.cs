namespace midis.muchik.market.domain.entities
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RoleId { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
    }
}
