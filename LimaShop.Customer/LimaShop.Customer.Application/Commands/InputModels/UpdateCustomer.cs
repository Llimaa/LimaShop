using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class UpdateCustomer : IRequest<Unit>
    {
        public UpdateCustomer(Guid customerId, string fullName, DateTime birthDate, string phoneNumber, string email)
        {
            CustomerId = customerId;
            FullName = fullName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
