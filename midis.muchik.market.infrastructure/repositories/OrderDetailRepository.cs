using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.infrastructure.repositories
{
    public class OrderDetailRepository : GenericRepository<OmnichannelContext, OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(OmnichannelContext context) : base(context) { }
    }
}
