using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class ActiveCustomerHander : IRequestHandler<ActiveCustomer, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public ActiveCustomerHander(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(ActiveCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            customer.ActiveCustomer();
            await _customerRepository.ActiveCustomer(customer);
            return Unit.Value;
        }
    }
}
