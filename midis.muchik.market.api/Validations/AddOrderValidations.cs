using FluentValidation;
using midis.muchik.market.application.dto.omnichannel;

namespace midis.muchik.market.api.Validations
{
    public class AddOrderValidations : AbstractValidator<AddOrderDto>
    {
        public AddOrderValidations()
        {
            RuleFor(m => m.Correlative).NotEmpty();
            RuleFor(m => m.CustomerId).NotEmpty();
            RuleFor(m => m.State).NotEmpty();
            RuleFor(m => m.Total).NotEmpty();
            RuleFor(m => m.OrderDetail).NotEmpty();
        }
    }
}
