using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var customer = request.ToEntity();

            await _customerRepository.Insert(customer);
            return customer.Id;
        }
    }
}
