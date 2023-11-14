using midis.muchik.market.domain.entities;

namespace midis.muchik.market.domain.interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(string productId);
        IEnumerable<Product> GetProductsByName(string search, string categoryId, string brandId, int skip, int take);
    }
}
