using FluentValidation;
using midis.muchik.market.application.dto.security;

namespace midis.muchik.market.api.Validations
{
    public class SignInRequestValidations : AbstractValidator<SignInRequestDto>
    {
        public SignInRequestValidations() 
        {
            RuleFor(m => m.Email).NotEmpty();
            RuleFor(m => m.Email).EmailAddress();
            RuleFor(m => m.Password).NotEmpty();        
        }
    }
}
