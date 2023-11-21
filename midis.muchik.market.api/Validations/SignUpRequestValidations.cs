using FluentValidation;
using midis.muchik.market.application.dto.security;

namespace midis.muchik.market.api.Validations
{
    public class SignUpRequestValidations : AbstractValidator<SignUpRequestDto>
    {
        public SignUpRequestValidations() 
        {
            RuleFor(m => m.Email).NotEmpty();
            RuleFor(m => m.Email).EmailAddress();
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.RoleId).NotEmpty();
        }
    }
}
