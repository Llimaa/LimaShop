using MediatR;
using System;
namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class ActiveCustomer : IRequest<Unit>
    {
        public ActiveCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; set; }
    }
}
