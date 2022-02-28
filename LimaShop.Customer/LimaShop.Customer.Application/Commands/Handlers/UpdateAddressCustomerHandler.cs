using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class UpdateAddressCustomerHandler : IRequestHandler<UpdateAddressCustomer, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateAddressCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateAddressCustomer request, CancellationToken cancellationToken)
        {
            await _customerRepository.UpdateAddressCustomer(request.AddressCustomer.ToEntity(), request.CustomerId);
            return Unit.Value;
        }
    }
}
