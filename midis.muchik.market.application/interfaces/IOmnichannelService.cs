using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.omnichannel;
using midis.muchik.market.crosscutting.models;

namespace midis.muchik.market.application.interfaces
{
    public interface IOmnichannelService
    {
        GenericResponse<OrderDto> AddOrder(AddOrderDto addOrderDto);
    }
}
