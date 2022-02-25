using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class UpdateAddressCustomer: IRequest<Unit>
    {
        public Guid CustomerId { get; set; }
        public AddressCustomer AddressCustomer { get; set; }
    }
}
