using FluentValidation;
using LimaShop.Customer.Application.Commands.InputModels;
using System;

namespace LimaShop.Customer.Application.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
    {
        public UpdateCustomerValidator()
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
        }
    }
}
