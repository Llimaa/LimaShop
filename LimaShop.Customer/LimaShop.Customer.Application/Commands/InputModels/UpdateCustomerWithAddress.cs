using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class UpdateCustomerWithAddress: IRequest<Unit>
    {
        public UpdateCustomerWithAddress(Guid customerId, string fullName, DateTime birthDate, string phoneNumber, string email, string country, string state, string city, string longradouro, string street, string number, string zipCore)
        {
            CustomerId = customerId;
            FullName = fullName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Country = country;
            State = state;
            City = city;
            Longradouro = longradouro;
            Street = street;
            Number = number;
            ZipCore = zipCore;
        }

        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; private set; }
        public string Longradouro { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCore { get; set; }
    }
}
