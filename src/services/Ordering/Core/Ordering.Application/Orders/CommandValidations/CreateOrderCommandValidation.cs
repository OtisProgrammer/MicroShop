using FluentValidation;
using Ordering.Application.Orders.Commands;

namespace Ordering.Application.Orders.CommandValidations
{
   public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
   {
       public CreateOrderCommandValidation()
       {
           RuleFor(a => a.Address)
               .NotEmpty().WithMessage("{Address} is required")
               .NotNull()
               .MaximumLength(500).WithMessage("{Address} must not exceed 500 characters");


           RuleFor(a => a.Description)
               .NotEmpty().WithMessage("{Description} is required")
               .NotNull()
               .MaximumLength(500).WithMessage("{Description} must not exceed 500 characters");
       }
   }
}
