using LimaShop.Customer.Application.ViewModel;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Queries
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            if (customers == null) return null;

            var customerViewModel = customers
                .Select(x => new CustomerViewModel(x.Id, x.FullName, x.BirthDate, x.PhoneNumber, AddressCustomerViewModel.FromEntity(x.Address), x.Email, x.Active))
                .ToList();
            return customerViewModel;
        }
    }
}
