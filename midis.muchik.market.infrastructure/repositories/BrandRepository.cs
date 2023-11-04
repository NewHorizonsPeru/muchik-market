using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(CommonContext context) : base(context) { }
    }
}
