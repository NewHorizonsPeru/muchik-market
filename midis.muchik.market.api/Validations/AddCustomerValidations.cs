using FluentValidation;
using midis.muchik.market.application.dto.common;

namespace midis.muchik.market.api.Validations
{
    public class AddCustomerValidations : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerValidations() 
        {
            RuleFor(m => m.FirstName).NotEmpty();
            RuleFor(m => m.LastName).NotEmpty();
            RuleFor(m => m.DocumentNumber).NotEmpty();
            RuleFor(m => m.PhoneNumber).NotEmpty();
            RuleFor(m => m.UserId).NotEmpty();
            RuleFor(m => m.BornedAt).NotEmpty();
        }
    }
}
