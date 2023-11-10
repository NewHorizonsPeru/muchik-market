namespace midis.muchik.market.domain.entities
{
    public partial class Category
    {
        public Category() 
        {
            Products = new HashSet<Product>();
        }
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Products { get; set; }
    }
}
