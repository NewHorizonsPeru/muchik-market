using midis.muchik.market.domain.entities;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class BrandRepository : GenericRepository<Brand>
    {
        public BrandRepository(MuchikContext context) : base(context) { }
    }
}
