using LimaShop.Customer.Application.ViewModel;
using MediatR;
using System;

namespace LimaShop.Customer.Application.Queries.GetById
{
    public class GetByIdCustomerQuery : IRequest<CustomerViewModel>
    {
        public GetByIdCustomerQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
