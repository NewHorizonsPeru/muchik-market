using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MuchikContext context) : base(context) { }
    }
}
