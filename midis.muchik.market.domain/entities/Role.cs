namespace midis.muchik.market.domain.entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<User> Users { get; set; }
    }
}
