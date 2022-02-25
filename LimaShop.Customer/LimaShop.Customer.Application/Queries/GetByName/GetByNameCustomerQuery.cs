using LimaShop.Customer.Application.ViewModel;
using MediatR;

namespace LimaShop.Customer.Application.Queries.GetByName
{
    public class GetByNameCustomerQuery : IRequest<CustomerViewModel>
    {
        public GetByNameCustomerQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
