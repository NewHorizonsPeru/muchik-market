namespace midis.muchik.market.domain.entities
{
    public class Brand
    {
        public Brand() 
        { 
            Products = new HashSet<Product>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
