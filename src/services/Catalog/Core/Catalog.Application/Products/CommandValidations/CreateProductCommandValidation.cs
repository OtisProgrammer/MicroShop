using Catalog.Application.Products.Commands;
using FluentValidation;

namespace Catalog.Application.Products.CommandValidations
{
   public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(a => a.Title)
                .NotEmpty().WithMessage("{Title} is required")
                .NotNull()
                .MaximumLength(150).WithMessage("{Title} must not exceed 150 characters");


            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("{Description} is required")
                .NotNull()
                .MaximumLength(150).WithMessage("{Description} must not exceed 150 characters");
        }
    }
}
