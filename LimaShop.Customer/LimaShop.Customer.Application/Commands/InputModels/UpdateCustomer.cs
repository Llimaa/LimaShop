using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class UpdateCustomer : IRequest<Unit>
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
