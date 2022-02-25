using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class UpdateCustomerWithAddress: IRequest<Unit>
    {
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
