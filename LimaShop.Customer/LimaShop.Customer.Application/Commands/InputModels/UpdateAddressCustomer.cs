using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class UpdateAddressCustomer: IRequest<Unit>
    {
        public UpdateAddressCustomer(Guid customerId, AddressCustomer addressCustomer)
        {
            CustomerId = customerId;
            AddressCustomer = addressCustomer;
        }

        public Guid CustomerId { get; set; }
        public AddressCustomer AddressCustomer { get; set; }
    }
}
