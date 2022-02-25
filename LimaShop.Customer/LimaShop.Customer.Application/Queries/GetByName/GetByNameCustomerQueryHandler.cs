using LimaShop.Customer.Application.ViewModel;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Queries.GetByName
{
    public class GetByNameCustomerQueryHandler : IRequestHandler<GetByNameCustomerQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetByNameCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> Handle(GetByNameCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByNameAsync(request.Name);

            if (customer == null) return null;

            var customerViewModel = new CustomerViewModel(
                customer.Id,
                customer.FullName,
                customer.BirthDate,
                customer.PhoneNumber,
                AddressCustomerViewModel.FromEntity(customer.Address), customer.Email, customer.Active);
            return customerViewModel;
        }
    }
}
