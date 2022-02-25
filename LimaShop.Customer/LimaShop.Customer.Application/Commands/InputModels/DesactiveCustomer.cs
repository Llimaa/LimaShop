using MediatR;
using System;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class DesactiveCustomer : IRequest<Unit>
    {
        public DesactiveCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; set; }
    }
}
