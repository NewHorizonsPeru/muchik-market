using FluentValidation;
using midis.muchik.market.application.dto.common;

namespace midis.muchik.market.api.Validations
{
    public class AddBrandDtoValidations : AbstractValidator<AddBrandDto>
    {
        public AddBrandDtoValidations() 
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Description).NotEmpty();
        }
    }
}
