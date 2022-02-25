using LimaShop.Customer.Application.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace LimaShop.Customer.Application.Queries
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerViewModel>>
    {
    }
}
