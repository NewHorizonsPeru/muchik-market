using AutoMapper;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.omnichannel;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.crosscutting.exceptions;
using midis.muchik.market.crosscutting.models;
using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;

namespace midis.muchik.market.application.services
{
    public class OmnichannelService : IOmnichannelService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OmnichannelService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public GenericResponse<OrderDto> AddOrder(AddOrderDto addOrderDto)
        {
            var orderEntity = _mapper.Map<Order>(addOrderDto);

            _orderRepository.Add(orderEntity);

            var successSave = _orderRepository.Save();

            if(!successSave) { throw new MuchikException("Ocurrió un error registrando la orden, vuelva a intentar en unos minutos."); }

            return new GenericResponse<OrderDto>(_mapper.Map<OrderDto>(orderEntity));
        }
    }
}
