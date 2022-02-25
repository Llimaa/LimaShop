using LimaShop.Customer.Application.ViewModel;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Queries.GetById
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
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
