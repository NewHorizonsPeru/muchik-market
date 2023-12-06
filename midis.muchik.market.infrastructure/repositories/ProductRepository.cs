using Microsoft.EntityFrameworkCore;
using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class ProductRepository : GenericRepository<CommonContext, Product>, IProductRepository
    {
        public ProductRepository(CommonContext context) : base(context) { }

        public IEnumerable<Product> GetProducts() 
        {
            return _context.Products
                .Include(s => s.Brand)
                .Include(w => w.Category);
        }

        public Product GetProductById(string productId)
        {
            return _context.Products
                .Include(s => s.Brand)
                .Include(w => w.Category)
                .FirstOrDefault(w => w.Id.Equals(productId))!;

        }

        public IEnumerable<Product> GetProductsByName(string search, string categoryId, string brandId, int skip, int take) 
        {
            var resultsFromSearch = _context.Products.Include(s => s.Brand)
													  .Include(w => w.Category).ToList();

			if (!string.IsNullOrEmpty(search))
			{
				resultsFromSearch = resultsFromSearch.Where(s => s.Name.ToUpper().Contains(search.ToUpper())).ToList();
			}

            if(!string.IsNullOrEmpty(categoryId)) {
                resultsFromSearch = resultsFromSearch.Where(s => s.CategoryId.Equals(categoryId)).ToList();
            }

            if (!string.IsNullOrEmpty(brandId))
            { 
                resultsFromSearch = resultsFromSearch.Where(s => s.BrandId.Equals(brandId)).ToList();
            }

            return resultsFromSearch.Skip(skip).Take(take);
        }
    }
}
