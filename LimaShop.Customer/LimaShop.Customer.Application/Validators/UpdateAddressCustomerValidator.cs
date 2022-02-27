using FluentValidation;
using LimaShop.Customer.Application.Commands.InputModels;

namespace LimaShop.Customer.Application.Validators
{
    public class UpdateAddressCustomerValidator : AbstractValidator<UpdateAddressCustomer>
    {
        public UpdateAddressCustomerValidator()
        {

            RuleFor(p => p.AddressCustomer.Country)
              .NotEmpty()
              .NotNull()
              .WithMessage("O campo país é obrigatório!");

            RuleFor(s => s.AddressCustomer.State)
                  .NotEmpty()
                .NotNull()
                .WithMessage("O campo estado é obrigatório!");

            RuleFor(s => s.AddressCustomer.City)
                .NotEmpty()
              .NotNull()
              .WithMessage("O campo cidate é obrigatório!");

            RuleFor(s => s.AddressCustomer.Longradouro)
                .NotEmpty()
              .NotNull()
              .WithMessage("O campo bairro é obrigatório!");

            RuleFor(s => s.AddressCustomer.Street)
                .NotEmpty()
              .NotNull()
              .WithMessage("O campo rua é obrigatório!");
        }
    }
}
