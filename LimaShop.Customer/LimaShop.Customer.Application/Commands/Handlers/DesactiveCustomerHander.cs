using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class DesactiveCustomerHander : IRequestHandler<DesactiveCustomer, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public DesactiveCustomerHander(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DesactiveCustomer request, CancellationToken cancellationToken)
        {
            await _customerRepository.DesactiveCustomer(request.CustomerId);
            return Unit.Value;
        }
    }
}
