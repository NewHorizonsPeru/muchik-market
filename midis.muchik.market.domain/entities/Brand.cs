namespace midis.muchik.market.domain.entities
{
    public partial class Brand
    {
        public Brand() 
        { 
            Products = new HashSet<Product>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Product> Products { get; set; }
    }
}
