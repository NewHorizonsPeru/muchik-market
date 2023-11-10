using Microsoft.EntityFrameworkCore;
using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class ProductRepository : GenericRepository<CommonContext, Product>, IProductRepository
    {
        public ProductRepository(CommonContext context) : base(context) { }

        public IEnumerable<Product> GetProducts() {
            return _context.Products
                .Include(s => s.Brand)
                .Include(w => w.Category);
        }
    }
}
