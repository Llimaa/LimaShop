using FluentValidation;
using LimaShop.Customer.Application.Commands.InputModels;
using System;

namespace LimaShop.Customer.Application.Validators
{
    public class UpdateCustomerWithAddressValidator : AbstractValidator<UpdateCustomerWithAddress>
    {
        public UpdateCustomerWithAddressValidator()
        {

            RuleFor(p => p.Email)
              .EmailAddress()
              .WithMessage("E-mail não válido!");

            RuleFor(p => p.FullName)
              .NotEmpty()
              .NotNull()
              .WithMessage("O Nome é obrigatório");

            RuleFor(p => p.PhoneNumber)
              .NotEmpty()
              .NotNull()
              .WithMessage("O número é obrigatório");

            RuleFor(p => p.BirthDate)
             .NotEmpty()
             .NotNull()
             .LessThan(DateTime.Now.AddYears(-17))
             .WithMessage("Customer precisa ter mais que 17 anos");

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
