using FluentValidation;
using midis.muchik.market.application.dto.common;

namespace midis.muchik.market.api.Validations
{
    public class AddProductValidations : AbstractValidator<AddProductDto>
    {
        public AddProductValidations() 
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Sku).NotEmpty();
            RuleFor(m => m.Price).NotEmpty();
            RuleFor(m => m.Description).NotEmpty();
            RuleFor(m => m.ImageUrl).NotEmpty();
            RuleFor(m => m.Score).NotEmpty();
            RuleFor(m => m.Stock).NotEmpty();
            RuleFor(m => m.CategoryId).NotEmpty();
            RuleFor(m => m.BrandId).NotEmpty();
        }
    }
}
