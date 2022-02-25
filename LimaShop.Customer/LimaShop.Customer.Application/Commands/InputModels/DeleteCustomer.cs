using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class DeleteCustomer: IRequest<bool>
    {
        public DeleteCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; set; }
    }
}
