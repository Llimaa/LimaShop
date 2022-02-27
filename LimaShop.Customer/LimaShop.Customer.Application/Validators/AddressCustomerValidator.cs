using FluentValidation;
using LimaShop.Customer.Application.Commands.InputModels;

namespace LimaShop.Customer.Application.Validators
{
    public class AddressCustomerValidator : AbstractValidator<AddressCustomer>
    {
        public AddressCustomerValidator()
        {
                RuleFor(p => p.Country)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O campo país é obrigatório!");

                RuleFor(s => s.State)
                      .NotEmpty()
                    .NotNull()
                    .WithMessage("O campo estado é obrigatório!");

                RuleFor(s => s.City)
                    .NotEmpty()
                  .NotNull()
                  .WithMessage("O campo cidate é obrigatório!");

                RuleFor(s => s.Longradouro)
                    .NotEmpty()
                  .NotNull()
                  .WithMessage("O campo bairro é obrigatório!");

                RuleFor(s => s.Street)
                    .NotEmpty()
                  .NotNull()
                  .WithMessage("O campo rua é obrigatório!");
        }
    }
}
