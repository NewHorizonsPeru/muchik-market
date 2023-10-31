using midis.muchik.market.domain.entities;

namespace midis.muchik.market.domain.interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProducts();
    }
}
