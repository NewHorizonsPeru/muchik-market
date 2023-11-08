using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class OrderRepository : GenericRepository<OmnichannelContext, Order>, IOrderRepository
    {
        public OrderRepository(OmnichannelContext context) : base(context) { }
    }
}
