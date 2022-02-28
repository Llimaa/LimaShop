using LimaShop.Customer.Core.Entities;
using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class CreateCustomer : IRequest<Guid>
    {
        public CreateCustomer(string fullName, DateTime birthDate, string phoneNumber, AddressCustomer address, string email)
        {
            FullName = fullName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
        }

        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public AddressCustomer Address { get; set; }
        public string Email { get; set; }
        public CustomerEntity ToEntity()
        {
            return new CustomerEntity(FullName, BirthDate, PhoneNumber, Address.ToEntity(), Email);
        }
    }
}
